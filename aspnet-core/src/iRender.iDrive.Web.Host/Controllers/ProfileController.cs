using Abp.AspNetCore.Mvc.Authorization;
using iRender.iDrive.Storage;

namespace iRender.iDrive.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(ITempFileCacheManager tempFileCacheManager) :
            base(tempFileCacheManager)
        {
        }
    }
}