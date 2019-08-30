using System.Collections.Generic;
using iRender.iDrive.Authorization.Users.Dto;
using iRender.iDrive.Dto;

namespace iRender.iDrive.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}