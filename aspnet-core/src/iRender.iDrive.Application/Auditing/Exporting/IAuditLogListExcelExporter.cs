using System.Collections.Generic;
using iRender.iDrive.Auditing.Dto;
using iRender.iDrive.Dto;

namespace iRender.iDrive.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
