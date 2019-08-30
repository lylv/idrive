using System.Collections.Generic;
using iRender.iDrive.Authorization.Permissions.Dto;

namespace iRender.iDrive.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}