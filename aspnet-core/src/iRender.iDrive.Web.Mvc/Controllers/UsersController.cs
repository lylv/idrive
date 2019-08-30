using Abp.AspNetCore.Mvc.Authorization;
using iRender.iDrive.Authorization;
using iRender.iDrive.Storage;
using Abp.BackgroundJobs;
using Abp.Authorization;

namespace iRender.iDrive.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}