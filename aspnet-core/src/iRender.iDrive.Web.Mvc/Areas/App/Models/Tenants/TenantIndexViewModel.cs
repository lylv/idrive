using System.Collections.Generic;
using iRender.iDrive.Editions.Dto;

namespace iRender.iDrive.Web.Areas.App.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}