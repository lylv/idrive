using iRender.iDrive.Sessions.Dto;

namespace iRender.iDrive.Web.Areas.App.Models.Layout
{
    public class FooterViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        public string GetProductNameWithEdition()
        {
            const string productName = "iDrive";

            if (LoginInformations.Tenant?.Edition?.DisplayName == null)
            {
                return productName;
            }

            return productName + " " + LoginInformations.Tenant.Edition.DisplayName;
        }
    }
}