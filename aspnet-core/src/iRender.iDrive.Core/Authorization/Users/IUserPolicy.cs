using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace iRender.iDrive.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
