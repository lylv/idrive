using Abp.AutoMapper;
using iRender.iDrive.Sessions.Dto;

namespace iRender.iDrive.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}