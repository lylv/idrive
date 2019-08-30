using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using iRender.iDrive.Configuration;
using iRender.iDrive.Web;

namespace iRender.iDrive.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class iDriveDbContextFactory : IDesignTimeDbContextFactory<iDriveDbContext>
    {
        public iDriveDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<iDriveDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: true);

            iDriveDbContextConfigurer.Configure(builder, configuration.GetConnectionString(iDriveConsts.ConnectionStringName));

            return new iDriveDbContext(builder.Options);
        }
    }
}