using System.Threading.Tasks;
using Abp.Application.Services;
using iRender.iDrive.MultiTenancy.Payments.Dto;
using iRender.iDrive.MultiTenancy.Payments.PayPal.Dto;

namespace iRender.iDrive.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalPaymentId, string paypalPayerId);

        PayPalConfigurationDto GetConfiguration();

        Task CancelPayment(CancelPaymentDto input);
    }
}
