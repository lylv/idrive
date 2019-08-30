using System.Collections.Generic;
using iRender.iDrive.Authorization.Users.Importing.Dto;
using iRender.iDrive.Dto;

namespace iRender.iDrive.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
