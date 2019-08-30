using iRender.iDrive.MultiTenancy.Payments;

namespace iRender.iDrive.Web.Models.Payment
{
    public class CancelPaymentModel
    {
        public string PaymentId { get; set; }

        public SubscriptionPaymentGatewayType Gateway { get; set; }
    }
}