using System;
using Abp.Domain.Entities;
using CentersFrontier.Production.Entities;

namespace CentersFrontier.Production.Tasks
{
    public class TransferRecord : Entity, IReceptionAudited
    {
        public long BatchId { get; set; }
        public ManufacturingBatch Batch { get; set; }

        public int DestinationId { get; set; }

        public string Remark { get; set; }

        public bool IsReceived { get; set; }
        public DateTime ReceptionTime { get; set; }
        public long? RecipientUserId { get; set; }
    }
}