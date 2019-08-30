using Microsoft.Extensions.Configuration;

namespace iRender.iDrive.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
