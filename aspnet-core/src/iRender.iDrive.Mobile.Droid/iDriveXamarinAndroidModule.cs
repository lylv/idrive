using Abp.Modules;
using Abp.Reflection.Extensions;

namespace iRender.iDrive
{
    [DependsOn(typeof(iDriveXamarinSharedModule))]
    public class iDriveXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(iDriveXamarinAndroidModule).GetAssembly());
        }
    }
}