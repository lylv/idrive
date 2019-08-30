using iRender.iDrive.Dto;

namespace iRender.iDrive.Common.Dto
{
    public class FindUsersInput : PagedAndFilteredInputDto
    {
        public int? TenantId { get; set; }
    }
}