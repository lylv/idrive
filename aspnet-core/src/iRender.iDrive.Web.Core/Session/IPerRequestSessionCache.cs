using System.Threading.Tasks;
using iRender.iDrive.Sessions.Dto;

namespace iRender.iDrive.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
