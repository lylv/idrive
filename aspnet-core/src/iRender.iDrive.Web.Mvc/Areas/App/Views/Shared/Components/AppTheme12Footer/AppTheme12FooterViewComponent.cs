using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iRender.iDrive.Web.Areas.App.Models.Layout;
using iRender.iDrive.Web.Session;
using iRender.iDrive.Web.Views;

namespace iRender.iDrive.Web.Areas.App.Views.Shared.Components.AppTheme12Footer
{
    public class AppTheme12FooterViewComponent : iDriveViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme12FooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
