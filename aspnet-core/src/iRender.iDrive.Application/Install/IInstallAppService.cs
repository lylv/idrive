using System.Threading.Tasks;
using Abp.Application.Services;
using iRender.iDrive.Install.Dto;

namespace iRender.iDrive.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}