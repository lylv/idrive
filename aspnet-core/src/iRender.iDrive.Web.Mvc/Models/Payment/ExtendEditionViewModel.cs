using System.Collections.Generic;
using iRender.iDrive.Editions.Dto;
using iRender.iDrive.MultiTenancy.Payments;

namespace iRender.iDrive.Web.Models.Payment
{
    public class ExtendEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}