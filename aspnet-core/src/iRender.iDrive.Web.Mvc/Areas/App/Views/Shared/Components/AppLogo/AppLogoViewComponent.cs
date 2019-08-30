using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iRender.iDrive.Web.Areas.App.Models.Layout;
using iRender.iDrive.Web.Session;
using iRender.iDrive.Web.Views;

namespace iRender.iDrive.Web.Areas.App.Views.Shared.Components.AppLogo
{
    public class AppLogoViewComponent : iDriveViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;
        
        public AppLogoViewComponent(
            IPerRequestSessionCache sessionCache
        )
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(string logoSkin = null)
        {
            var headerModel = new LogoViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync(),
                LogoSkinOverride = logoSkin
            };
            
            return View(headerModel);
        }
    }
}
