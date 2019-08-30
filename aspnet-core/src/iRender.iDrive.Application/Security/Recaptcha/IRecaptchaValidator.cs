using System.Threading.Tasks;

namespace iRender.iDrive.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}