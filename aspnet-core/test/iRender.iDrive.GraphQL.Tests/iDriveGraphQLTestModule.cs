using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using iRender.iDrive.Configure;
using iRender.iDrive.Startup;
using iRender.iDrive.Test.Base;

namespace iRender.iDrive.GraphQL.Tests
{
    [DependsOn(
        typeof(iDriveGraphQLModule),
        typeof(iDriveTestBaseModule))]
    public class iDriveGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(iDriveGraphQLTestModule).GetAssembly());
        }
    }
}