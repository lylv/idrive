using iRender.iDrive.Sessions.Dto;

namespace iRender.iDrive.Web.Views.Shared.Components.AccountLogo
{
    public class AccountLogoViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; }

        private string _skin = "light";

        public AccountLogoViewModel(GetCurrentLoginInformationsOutput loginInformations, string skin)
        {
            LoginInformations = loginInformations;
            _skin = skin;
        }

        public string GetLogoUrl(string appPath)
        {
            if (LoginInformations.Tenant?.LogoId == null)
            {
                return appPath + "Common/Images/app-logo-on-" + _skin + ".svg";
            }

            return appPath + "TenantCustomization/GetLogo?id=" + LoginInformations.Tenant.LogoId;
        }
    }
}