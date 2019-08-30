using System.Threading.Tasks;
using Abp.Application.Services;
using iRender.iDrive.Configuration.Host.Dto;

namespace iRender.iDrive.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
