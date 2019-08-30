using System.Collections.Generic;
using Abp.Localization;
using iRender.iDrive.Install.Dto;

namespace iRender.iDrive.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
