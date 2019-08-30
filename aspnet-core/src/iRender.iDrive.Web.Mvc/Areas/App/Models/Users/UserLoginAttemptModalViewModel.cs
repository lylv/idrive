using System.Collections.Generic;
using iRender.iDrive.Authorization.Users.Dto;

namespace iRender.iDrive.Web.Areas.App.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}