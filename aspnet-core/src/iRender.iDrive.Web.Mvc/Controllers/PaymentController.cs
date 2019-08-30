﻿using Abp.Extensions;
using Abp.Runtime.Session;
using Abp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using iRender.iDrive.Editions;
using iRender.iDrive.MultiTenancy;
using iRender.iDrive.MultiTenancy.Dto;
using iRender.iDrive.MultiTenancy.Payments;
using iRender.iDrive.MultiTenancy.Payments.Dto;
using iRender.iDrive.Url;
using iRender.iDrive.Web.Models.Payment;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Abp.Authorization.Users;
using Microsoft.AspNetCore.Identity;
using iRender.iDrive.Authorization;
using iRender.iDrive.Authorization.Roles;
using iRender.iDrive.Authorization.Users;
using iRender.iDrive.Identity;

namespace iRender.iDrive.Web.Controllers
{
    public class PaymentController : iDriveControllerBase
    {
        private readonly IPaymentAppService _paymentAppService;
        private readonly ITenantRegistrationAppService _tenantRegistrationAppService;
        private readonly TenantManager _tenantManager;
        private readonly EditionManager _editionManager;
        private readonly ISubscriptionAppService _subscriptionAppService;
        private readonly IWebUrlService _webUrlService;
        private readonly ISubscriptionPaymentRepository _subscriptionPaymentRepository;
        private readonly UserClaimsPrincipalFactory<User, Role> _userClaimsPrincipalFactory;
        private readonly UserManager _userManager;
        private readonly SignInManager _signInManager;

        public PaymentController(
            IPaymentAppService paymentAppService,
            ITenantRegistrationAppService tenantRegistrationAppService,
            TenantManager tenantManager,
            EditionManager editionManager,
            ISubscriptionAppService subscriptionAppService,
            IWebUrlService webUrlService,
            ISubscriptionPaymentRepository subscriptionPaymentRepository,
            UserClaimsPrincipalFactory<User, Role> userClaimsPrincipalFactory,
            UserManager userManager,
            SignInManager signInManager)
        {
            _paymentAppService = paymentAppService;
            _tenantRegistrationAppService = tenantRegistrationAppService;
            _tenantManager = tenantManager;
            _editionManager = editionManager;
            _subscriptionAppService = subscriptionAppService;
            _webUrlService = webUrlService;
            _subscriptionPaymentRepository = subscriptionPaymentRepository;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Buy(int tenantId, int editionId, int? subscriptionStartType, int? editionPaymentType)
        {
            SetTenantIdCookie(tenantId);

            var edition = await _tenantRegistrationAppService.GetEdition(editionId);

            var model = new BuyEditionViewModel
            {
                Edition = edition,
                PaymentGateways = _paymentAppService.GetActiveGateways(new GetActiveGatewaysInput())
            };

            if (editionPaymentType.HasValue)
            {
                model.EditionPaymentType = (EditionPaymentType)editionPaymentType.Value;
            }

            if (subscriptionStartType.HasValue)
            {
                model.SubscriptionStartType = (SubscriptionStartType)subscriptionStartType.Value;
            }

            return View("Buy", model);
        }

        public async Task<IActionResult> Upgrade(int upgradeEditionId)
        {
            if (await UpgradeIsFree(upgradeEditionId))
            {
                await _subscriptionAppService.UpgradeTenantToEquivalentEdition(upgradeEditionId);
                return RedirectToAction("Index", "SubscriptionManagement", new { area = "App" });
            }

            if (!AbpSession.TenantId.HasValue)
            {
                throw new ArgumentNullException();
            }

            SubscriptionPaymentType subscriptionPaymentType;

            using (CurrentUnitOfWork.SetTenantId(null))
            {
                var tenant = await _tenantManager.GetByIdAsync(AbpSession.GetTenantId());
                subscriptionPaymentType = tenant.SubscriptionPaymentType;

                if (tenant.EditionId.HasValue)
                {
                    var currentEdition = await _editionManager.GetByIdAsync(tenant.EditionId.Value);
                    if (((SubscribableEdition)currentEdition).IsFree)
                    {
                        return RedirectToAction("Buy", "Payment", new
                        {
                            tenantId = AbpSession.GetTenantId(),
                            editionId = upgradeEditionId
                        });
                    }
                }
            }

            var paymentInfo = await _paymentAppService.GetPaymentInfo(new PaymentInfoInput { UpgradeEditionId = upgradeEditionId });
            var edition = await _tenantRegistrationAppService.GetEdition(upgradeEditionId);

            var lastPayment = await _subscriptionPaymentRepository.GetLastCompletedPaymentOrDefaultAsync(
                tenantId: AbpSession.GetTenantId(),
                gateway: null,
                isRecurring: null);

            var model = new UpgradeEditionViewModel
            {
                Edition = edition,
                AdditionalPrice = paymentInfo.AdditionalPrice,
                SubscriptionPaymentType = subscriptionPaymentType,
                PaymentPeriodType = lastPayment.GetPaymentPeriodType()
            };

            if (subscriptionPaymentType.IsRecurring())
            {
                model.PaymentGateways = new List<PaymentGatewayModel>
                {
                    new PaymentGatewayModel
                    {
                        GatewayType = lastPayment.Gateway,
                        SupportsRecurringPayments = true
                    }
                };
            }
            else
            {
                model.PaymentGateways = _paymentAppService.GetActiveGateways(new GetActiveGatewaysInput());
            }

            return View("Upgrade", model);
        }

        public async Task<IActionResult> Extend(int upgradeEditionId, EditionPaymentType editionPaymentType)
        {
            var edition = await _tenantRegistrationAppService.GetEdition(upgradeEditionId);

            var model = new ExtendEditionViewModel
            {
                Edition = edition,
                PaymentGateways = _paymentAppService.GetActiveGateways(new GetActiveGatewaysInput())
            };

            return View("Extend", model);
        }

        [HttpPost]
        public async Task<JsonResult> CreatePayment(CreatePaymentModel model)
        {
            var paymentId = await _paymentAppService.CreatePayment(new CreatePaymentDto
            {
                PaymentPeriodType = model.PaymentPeriodType,
                EditionId = model.EditionId,
                EditionPaymentType = model.EditionPaymentType,
                RecurringPaymentEnabled = model.RecurringPaymentEnabled.HasValue && model.RecurringPaymentEnabled.Value,
                SubscriptionPaymentGatewayType = model.Gateway,
                SuccessUrl = _webUrlService.GetSiteRootAddress().EnsureEndsWith('/') + "Payment/" + model.EditionPaymentType + "Succeed",
                ErrorUrl = _webUrlService.GetSiteRootAddress().EnsureEndsWith('/') + "Payment/PaymentFailed"
            });

            return Json(new AjaxResponse
            {
                TargetUrl = Url.Action("Purchase", model.Gateway.ToString(), new
                {
                    paymentId = paymentId,
                    isUpgrade = model.EditionPaymentType == EditionPaymentType.Upgrade
                })
            });
        }

        [HttpPost]
        public async Task CancelPayment(CancelPaymentModel model)
        {
            await _paymentAppService.CancelPayment(new CancelPaymentDto
            {
                Gateway = model.Gateway,
                PaymentId = model.PaymentId
            });
        }

        public async Task<IActionResult> BuyNowSucceed(long paymentId)
        {
            await _paymentAppService.BuyNowSucceed(paymentId);

            return RedirectToAction("Index", "SubscriptionManagement", new { area = "App" });
        }

        public async Task<IActionResult> NewRegistrationSucceed(long paymentId)
        {
            await _paymentAppService.NewRegistrationSucceed(paymentId);
            
            await LoginAdminAsync();

            return RedirectToAction("Index", "SubscriptionManagement", new { area = "App" });
        }

        public async Task<IActionResult> UpgradeSucceed(long paymentId)
        {
            await _paymentAppService.UpgradeSucceed(paymentId);

            return RedirectToAction("Index", "SubscriptionManagement", new { area = "App" });
        }

        public async Task<IActionResult> ExtendSucceed(long paymentId)
        {
            await _paymentAppService.ExtendSucceed(paymentId);

            return RedirectToAction("Index", "SubscriptionManagement", new { area = "App" });
        }

        public async Task<IActionResult> PaymentFailed(long paymentId)
        {
            await _paymentAppService.PaymentFailed(paymentId);

            if (AbpSession.UserId.HasValue)
            {
                return RedirectToAction("Index", "SubscriptionManagement", new { area = "App" });
            }

            return RedirectToAction("Index", "Home", new { area = "App" });
        }

        private async Task<bool> UpgradeIsFree(int upgradeEditionId)
        {
            var tenant = await _tenantManager.GetByIdAsync(AbpSession.GetTenantId());

            if (!tenant.EditionId.HasValue)
            {
                throw new Exception("Tenant must be assigned to an Edition in order to upgrade !");
            }

            var currentEdition = (SubscribableEdition)await _editionManager.GetByIdAsync(tenant.EditionId.Value);
            var targetEdition = (SubscribableEdition)await _editionManager.GetByIdAsync(upgradeEditionId);
            var bothEditionsAreFree = targetEdition.IsFree && currentEdition.IsFree;
            var bothEditionsHasSamePrice = currentEdition.HasSamePrice(targetEdition);
            return bothEditionsAreFree || bothEditionsHasSamePrice;
        }

        private async Task LoginAdminAsync()
        {
            var user = await _userManager.GetAdminAsync();
            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);
            
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(principal.Identity as ClaimsIdentity, false);
        }
    }
}