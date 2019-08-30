using System.Collections.Generic;
using iRender.iDrive.Caching.Dto;

namespace iRender.iDrive.Web.Areas.App.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}