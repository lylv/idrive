using System.Threading.Tasks;

namespace iRender.iDrive.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}