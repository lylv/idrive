using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using iRender.iDrive.Configuration.Dto;

namespace iRender.iDrive.Configuration
{
    public interface IUiCustomizationSettingsAppService : IApplicationService
    {
        Task<List<ThemeSettingsDto>> GetUiManagementSettings();

        Task UpdateUiManagementSettings(ThemeSettingsDto settings);

        Task UpdateDefaultUiManagementSettings(ThemeSettingsDto settings);

        Task UseSystemDefaultSettings();
    }
}
