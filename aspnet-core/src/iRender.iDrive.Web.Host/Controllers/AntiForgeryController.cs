using Microsoft.AspNetCore.Antiforgery;

namespace iRender.iDrive.Web.Controllers
{
    public class AntiForgeryController : iDriveControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
