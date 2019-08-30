using Abp.AutoMapper;
using iRender.iDrive.Editions;
using iRender.iDrive.MultiTenancy.Payments.Dto;

namespace iRender.iDrive.Web.Areas.App.Models.SubscriptionManagement
{
    [AutoMapTo(typeof(ExecutePaymentDto))]
    public class PaymentResultViewModel : SubscriptionPaymentDto
    {
        public EditionPaymentType EditionPaymentType { get; set; }
    }
}