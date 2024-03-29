﻿using System;
using Abp.AutoMapper;
using iRender.iDrive.Sessions.Dto;

namespace iRender.iDrive.Models.Common
{
    [AutoMapFrom(typeof(ApplicationInfoDto)),
     AutoMapTo(typeof(ApplicationInfoDto))]
    public class ApplicationInfoPersistanceModel
    {
        public string Version { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}