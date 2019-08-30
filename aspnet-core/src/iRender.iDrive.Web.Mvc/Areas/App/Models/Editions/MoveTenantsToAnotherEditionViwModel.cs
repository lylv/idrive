using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace iRender.iDrive.Web.Areas.App.Models.Editions
{
    public class MoveTenantsToAnotherEditionViwModel
    {
        public int EditionId { get; set; }

        public int TenantCount { get; set; }

        public IReadOnlyList<ComboboxItemDto> EditionItems { get; set; }
    }
}