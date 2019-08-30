using Abp.AspNetCore.Mvc.ViewComponents;

namespace iRender.iDrive.Web.Public.Views
{
    public abstract class iDriveViewComponent : AbpViewComponent
    {
        protected iDriveViewComponent()
        {
            LocalizationSourceName = iDriveConsts.LocalizationSourceName;
        }
    }
}