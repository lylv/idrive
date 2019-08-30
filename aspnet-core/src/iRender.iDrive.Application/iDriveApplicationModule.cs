using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using iRender.iDrive.Authorization;

namespace iRender.iDrive
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(iDriveCoreModule)
        )]
    public class iDriveApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(iDriveApplicationModule).GetAssembly());
        }
    }
}