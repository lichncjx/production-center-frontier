using Abp.Events.Bus;

namespace CentersFrontier.Production.Tasks.Events
{
    public class DeliveryConfirmed : EventData
    {
        public int DeliveryRecordId { get; set; }
        public long BatchId { get; set; }
        public long TaskId { get; set; }
        public int DestinationId { get; set; }
    }
}