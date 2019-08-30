using Abp.AutoMapper;
using iRender.iDrive.MultiTenancy.Dto;

namespace iRender.iDrive.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
        public EditionsSelectViewModel(EditionsSelectOutput output)
        {
            output.MapTo(this);
        }
    }
}
