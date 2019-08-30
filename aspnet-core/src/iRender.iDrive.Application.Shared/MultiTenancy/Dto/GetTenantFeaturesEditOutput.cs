using System.Collections.Generic;
using Abp.Application.Services.Dto;
using iRender.iDrive.Editions.Dto;

namespace iRender.iDrive.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}