using Abp.Dependency;
using GraphQL;
using GraphQL.Types;
using iRender.iDrive.Queries.Container;

namespace iRender.iDrive.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IDependencyResolver resolver) :
            base(resolver)
        {
            Query = resolver.Resolve<QueryContainer>();
        }
    }
}