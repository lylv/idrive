using Abp.Auditing;
using iRender.iDrive.Configuration.Dto;

namespace iRender.iDrive.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}