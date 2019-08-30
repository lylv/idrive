using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using iRender.iDrive.Authorization;
using iRender.iDrive.Authorization.Permissions;
using iRender.iDrive.Authorization.Roles;
using iRender.iDrive.Web.Areas.App.Models.Roles;
using iRender.iDrive.Web.Controllers;

namespace iRender.iDrive.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Roles)]
    public class RolesController : iDriveControllerBase
    {
        private readonly IRoleAppService _roleAppService;
        private readonly IPermissionAppService _permissionAppService;

        public RolesController(
            IRoleAppService roleAppService,
            IPermissionAppService permissionAppService)
        {
            _roleAppService = roleAppService;
            _permissionAppService = permissionAppService;
        }

        public ActionResult Index()
        {
            var permissions = _permissionAppService.GetAllPermissions()
                                                .Items
                                                .Select(p => new ComboboxItemDto(p.Name, new string('-', p.Level * 2) + " " + p.DisplayName))
                                                .ToList();

            permissions.Insert(0, new ComboboxItemDto("", ""));
            var model = new RoleListViewModel
            {
                Permissions = permissions
            };

            return View(model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_Roles_Create, AppPermissions.Pages_Administration_Roles_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = await _roleAppService.GetRoleForEdit(new NullableIdDto { Id = id });
            var viewModel = new CreateOrEditRoleModalViewModel(output);

            return PartialView("_CreateOrEditModal", viewModel);
        }
    }
}