using Abp.Modules;
using Abp.Reflection.Extensions;

namespace iRender.iDrive
{
    [DependsOn(typeof(iDriveXamarinSharedModule))]
    public class iDriveXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(iDriveXamarinIosModule).GetAssembly());
        }
    }
}