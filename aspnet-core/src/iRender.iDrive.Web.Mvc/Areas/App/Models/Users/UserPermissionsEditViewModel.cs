﻿using Abp.AutoMapper;
using iRender.iDrive.Authorization.Users;
using iRender.iDrive.Authorization.Users.Dto;
using iRender.iDrive.Web.Areas.App.Models.Common;

namespace iRender.iDrive.Web.Areas.App.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}