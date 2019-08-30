using Abp.Authorization;
using iRender.iDrive.Authorization.Roles;
using iRender.iDrive.Authorization.Users;

namespace iRender.iDrive.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
