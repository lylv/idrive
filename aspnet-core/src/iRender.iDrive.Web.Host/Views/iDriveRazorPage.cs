using Abp.AspNetCore.Mvc.Views;

namespace iRender.iDrive.Web.Views
{
    public abstract class iDriveRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected iDriveRazorPage()
        {
            LocalizationSourceName = iDriveConsts.LocalizationSourceName;
        }
    }
}
