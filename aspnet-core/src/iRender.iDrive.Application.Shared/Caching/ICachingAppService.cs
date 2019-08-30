using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using iRender.iDrive.Caching.Dto;

namespace iRender.iDrive.Caching
{
    public interface ICachingAppService : IApplicationService
    {
        ListResultDto<CacheDto> GetAllCaches();

        Task ClearCache(EntityDto<string> input);

        Task ClearAllCaches();
    }
}
