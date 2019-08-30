using System.Threading.Tasks;
using Abp.Application.Services;
using iRender.iDrive.MultiTenancy.Payments.Stripe.Dto;

namespace iRender.iDrive.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        Task CreateSubscription(StripeCreateSubscriptionInput input);

        Task UpdateSubscription(StripeUpdateSubscriptionInput input);
        
        StripeConfigurationDto GetConfiguration();
    }
}