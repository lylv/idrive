using iRender.iDrive.EntityFrameworkCore;

namespace iRender.iDrive.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly iDriveDbContext _context;

        public InitialHostDbBuilder(iDriveDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
