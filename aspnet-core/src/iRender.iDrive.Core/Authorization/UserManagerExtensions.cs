using System.Threading.Tasks;
using Abp.Authorization.Users;
using iRender.iDrive.Authorization.Users;

namespace iRender.iDrive.Authorization
{
    public static class UserManagerExtensions
    {
        public static async Task<User> GetAdminAsync(this UserManager userManager)
        {
            return await userManager.FindByNameAsync(AbpUserBase.AdminUserName);
        }
    }
}
