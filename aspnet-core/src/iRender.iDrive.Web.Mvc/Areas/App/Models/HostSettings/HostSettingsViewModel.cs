using System.Collections.Generic;
using Abp.Application.Services.Dto;
using iRender.iDrive.Configuration.Host.Dto;
using iRender.iDrive.Editions.Dto;

namespace iRender.iDrive.Web.Areas.App.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}