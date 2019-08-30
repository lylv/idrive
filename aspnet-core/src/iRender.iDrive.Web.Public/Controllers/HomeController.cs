using Microsoft.AspNetCore.Mvc;
using iRender.iDrive.Web.Controllers;

namespace iRender.iDrive.Web.Public.Controllers
{
    public class HomeController : iDriveControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}