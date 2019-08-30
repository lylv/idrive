using Abp.Domain.Services;

namespace iRender.iDrive
{
    public abstract class iDriveDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected iDriveDomainServiceBase()
        {
            LocalizationSourceName = iDriveConsts.LocalizationSourceName;
        }
    }
}
