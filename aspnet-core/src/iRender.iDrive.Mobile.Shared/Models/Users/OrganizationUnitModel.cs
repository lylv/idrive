using Abp.AutoMapper;
using iRender.iDrive.Organizations.Dto;

namespace iRender.iDrive.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}