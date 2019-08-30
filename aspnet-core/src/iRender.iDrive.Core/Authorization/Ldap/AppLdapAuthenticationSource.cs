using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using iRender.iDrive.Authorization.Users;
using iRender.iDrive.MultiTenancy;

namespace iRender.iDrive.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}