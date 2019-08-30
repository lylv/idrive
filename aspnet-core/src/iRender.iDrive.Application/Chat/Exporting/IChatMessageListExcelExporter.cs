using System.Collections.Generic;
using iRender.iDrive.Chat.Dto;
using iRender.iDrive.Dto;

namespace iRender.iDrive.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(List<ChatMessageExportDto> messages);
    }
}
