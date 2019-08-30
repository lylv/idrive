using Abp.AutoMapper;
using iRender.iDrive.MultiTenancy;
using iRender.iDrive.MultiTenancy.Dto;
using iRender.iDrive.Web.Areas.App.Models.Common;

namespace iRender.iDrive.Web.Areas.App.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}