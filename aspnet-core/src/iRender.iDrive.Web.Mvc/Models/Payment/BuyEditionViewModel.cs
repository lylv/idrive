using System.Collections.Generic;
using iRender.iDrive.Editions;
using iRender.iDrive.Editions.Dto;
using iRender.iDrive.MultiTenancy.Payments;
using iRender.iDrive.MultiTenancy.Payments.Dto;

namespace iRender.iDrive.Web.Models.Payment
{
    public class BuyEditionViewModel
    {
        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}
