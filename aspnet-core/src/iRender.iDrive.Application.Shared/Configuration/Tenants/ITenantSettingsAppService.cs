using System.Threading.Tasks;
using Abp.Application.Services;
using iRender.iDrive.Configuration.Tenants.Dto;

namespace iRender.iDrive.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
