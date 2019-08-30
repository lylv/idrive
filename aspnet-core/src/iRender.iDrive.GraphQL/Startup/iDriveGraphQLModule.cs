using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace iRender.iDrive.Startup
{
    [DependsOn(typeof(iDriveCoreModule))]
    public class iDriveGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(iDriveGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}