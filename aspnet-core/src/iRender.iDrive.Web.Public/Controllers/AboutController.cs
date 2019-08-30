using Microsoft.AspNetCore.Mvc;
using iRender.iDrive.Web.Controllers;

namespace iRender.iDrive.Web.Public.Controllers
{
    public class AboutController : iDriveControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}