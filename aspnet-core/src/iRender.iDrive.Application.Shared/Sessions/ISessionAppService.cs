using System.Threading.Tasks;
using Abp.Application.Services;
using iRender.iDrive.Sessions.Dto;

namespace iRender.iDrive.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
