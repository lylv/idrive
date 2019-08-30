using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;

namespace iRender.iDrive.Web.Controllers
{
    public class HomeController : iDriveControllerBase
    {
        [DisableAuditing]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Ui");
        }
    }
}
