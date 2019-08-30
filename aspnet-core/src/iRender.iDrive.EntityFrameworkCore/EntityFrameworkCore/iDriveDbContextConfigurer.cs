using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace iRender.iDrive.EntityFrameworkCore
{
    public static class iDriveDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<iDriveDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<iDriveDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}