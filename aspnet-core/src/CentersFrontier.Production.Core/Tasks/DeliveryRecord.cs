using System;
using Abp.Domain.Entities;
using Abp.Events.Bus;
using Abp.Timing;
using CentersFrontier.Production.Entities;
using CentersFrontier.Production.Tasks.Events;

namespace CentersFrontier.Production.Tasks
{
    public class DeliveryRecord : Entity, IReceptionAudited
    {
        public int DestinationId { get; set; }

        public string Remark { get; set; }

        public bool IsReceived { get; set; }
        public DateTime ReceptionTime { get; set; }
        public long? RecipientUserId { get; set; }

        public long BatchId { get; set; }
        public ManufacturingBatch Batch { get; set; }

        public long TaskId { get; set; }
        public ManufacturingTask Task { get; set; }

        public void Sign(long recipientUserId, string remark)
        {
            IsReceived = true;
            RecipientUserId = recipientUserId;
            ReceptionTime = Clock.Now;
            Remark = remark;
            EventBus.Default.Trigger(this, new DeliveryConfirmed
            {
                BatchId = BatchId,
                TaskId = TaskId,
                DestinationId = DestinationId,
                DeliveryRecordId = Id
            });
        }
    }
}