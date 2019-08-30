using System.Collections.Generic;
using iRender.iDrive.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace iRender.iDrive.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
