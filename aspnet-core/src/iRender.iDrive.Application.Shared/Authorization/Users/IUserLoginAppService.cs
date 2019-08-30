using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using iRender.iDrive.Authorization.Users.Dto;

namespace iRender.iDrive.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<ListResultDto<UserLoginAttemptDto>> GetRecentUserLoginAttempts();
    }
}
