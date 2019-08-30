﻿using System.Collections.Generic;
using Abp.Application.Services.Dto;
using iRender.iDrive.Editions.Dto;

namespace iRender.iDrive.Web.Areas.App.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}