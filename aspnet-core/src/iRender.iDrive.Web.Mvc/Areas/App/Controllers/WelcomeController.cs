using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using iRender.iDrive.Web.Controllers;

namespace iRender.iDrive.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize]
    public class WelcomeController : iDriveControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}