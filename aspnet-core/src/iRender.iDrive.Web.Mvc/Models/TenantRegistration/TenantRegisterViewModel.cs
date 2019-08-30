using iRender.iDrive.Editions;
using iRender.iDrive.Editions.Dto;
using iRender.iDrive.MultiTenancy.Payments;
using iRender.iDrive.Security;
using iRender.iDrive.MultiTenancy.Payments.Dto;

namespace iRender.iDrive.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
