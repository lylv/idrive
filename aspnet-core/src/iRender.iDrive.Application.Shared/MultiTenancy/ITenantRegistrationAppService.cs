using System.Threading.Tasks;
using Abp.Application.Services;
using iRender.iDrive.Editions.Dto;
using iRender.iDrive.MultiTenancy.Dto;

namespace iRender.iDrive.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}