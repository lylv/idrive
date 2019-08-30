using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace iRender.iDrive.Web.Public.Views
{
    public abstract class iDriveRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected iDriveRazorPage()
        {
            LocalizationSourceName = iDriveConsts.LocalizationSourceName;
        }
    }
}
