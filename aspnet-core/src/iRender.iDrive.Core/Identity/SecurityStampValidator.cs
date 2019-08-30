using Abp.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using iRender.iDrive.Authorization.Roles;
using iRender.iDrive.Authorization.Users;
using iRender.iDrive.MultiTenancy;

namespace iRender.iDrive.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options, 
            SignInManager signInManager,
            ISystemClock systemClock)
            : base(options, signInManager, systemClock)
        {
        }
    }
}