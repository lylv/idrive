using System.Threading.Tasks;
using iRender.iDrive.Security.Recaptcha;

namespace iRender.iDrive.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
