using Abp.Application.Services;
using Abp.Application.Services.Dto;
using iRender.iDrive.Authorization.Permissions.Dto;

namespace iRender.iDrive.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
