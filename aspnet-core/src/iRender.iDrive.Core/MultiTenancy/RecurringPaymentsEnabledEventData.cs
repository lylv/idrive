using Abp.Events.Bus;

namespace iRender.iDrive.MultiTenancy
{
    public class RecurringPaymentsEnabledEventData : EventData
    {
        public int TenantId { get; set; }
    }
}