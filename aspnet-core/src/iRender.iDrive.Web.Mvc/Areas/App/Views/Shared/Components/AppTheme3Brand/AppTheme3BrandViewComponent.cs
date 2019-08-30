using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iRender.iDrive.Web.Areas.App.Models.Layout;
using iRender.iDrive.Web.Session;
using iRender.iDrive.Web.Views;

namespace iRender.iDrive.Web.Areas.App.Views.Shared.Components.AppTheme3Brand
{
    public class AppTheme3BrandViewComponent : iDriveViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme3BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
