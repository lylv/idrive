using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace iRender.iDrive
{
    [DependsOn(typeof(iDriveClientModule), typeof(AbpAutoMapperModule))]
    public class iDriveXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(iDriveXamarinSharedModule).GetAssembly());
        }
    }
}