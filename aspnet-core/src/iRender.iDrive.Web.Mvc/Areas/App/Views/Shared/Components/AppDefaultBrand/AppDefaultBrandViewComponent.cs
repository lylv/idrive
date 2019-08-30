using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iRender.iDrive.Web.Areas.App.Models.Layout;
using iRender.iDrive.Web.Session;
using iRender.iDrive.Web.Views;

namespace iRender.iDrive.Web.Areas.App.Views.Shared.Components.AppDefaultBrand
{
    public class AppDefaultBrandViewComponent : iDriveViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppDefaultBrandViewComponent(IPerRequestSessionCache sessionCache)
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
