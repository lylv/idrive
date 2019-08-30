using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using iRender.iDrive.Authorization;
using iRender.iDrive.Web.Areas.App.Models.HostDashboard;
using iRender.iDrive.Web.Controllers;

namespace iRender.iDrive.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Host_Dashboard)]
    public class HostDashboardController : iDriveControllerBase
    {
        private const int DashboardOnLoadReportDayCount = 7;

        public ActionResult Index()
        {
            return View(new HostDashboardViewModel(DashboardOnLoadReportDayCount));
        }
    }
}