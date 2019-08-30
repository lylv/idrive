using Abp.Application.Services;
using iRender.iDrive.Dto;
using iRender.iDrive.Logging.Dto;

namespace iRender.iDrive.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
