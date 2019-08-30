using Abp.AutoMapper;
using iRender.iDrive.MultiTenancy.Dto;

namespace iRender.iDrive.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}