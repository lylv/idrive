using System.Collections.Generic;
using Abp.Application.Services.Dto;
using iRender.iDrive.Configuration.Tenants.Dto;

namespace iRender.iDrive.Web.Areas.App.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}