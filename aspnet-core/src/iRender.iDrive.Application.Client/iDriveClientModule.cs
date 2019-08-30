using Abp.Modules;
using Abp.Reflection.Extensions;

namespace iRender.iDrive
{
    public class iDriveClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(iDriveClientModule).GetAssembly());
        }
    }
}
