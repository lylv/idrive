using System.Collections.Generic;
using iRender.iDrive.Authorization.Permissions.Dto;

namespace iRender.iDrive.Web.Areas.App.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}