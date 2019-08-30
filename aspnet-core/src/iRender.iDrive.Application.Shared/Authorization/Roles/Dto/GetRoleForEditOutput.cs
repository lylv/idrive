﻿using System.Collections.Generic;
using iRender.iDrive.Authorization.Permissions.Dto;

namespace iRender.iDrive.Authorization.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}