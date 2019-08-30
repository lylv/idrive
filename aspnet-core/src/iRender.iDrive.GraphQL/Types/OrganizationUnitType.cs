using GraphQL.Types;
using iRender.iDrive.Dto;

namespace iRender.iDrive.Types
{
    public class OrganizationUnitType : ObjectGraphType<OrganizationUnitDto>
    {
        public OrganizationUnitType()
        {
            Field(x => x.Id);
            Field(x => x.Code);
            Field(x => x.DisplayName);
            Field(x => x.TenantId, nullable: true);
        }
    }
}