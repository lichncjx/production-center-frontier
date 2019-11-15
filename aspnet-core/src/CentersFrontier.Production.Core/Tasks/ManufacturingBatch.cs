using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using CentersFrontier.Production.Entities;
using CentersFrontier.Production.Quality;

namespace CentersFrontier.Production.Tasks
{
    public class ManufacturingBatch : FullAuditedEntity<long>, IPassivable
    {
        public ManufacturingBatch(string batchCode, int quantity, long taskId)
        {
            BatchCode = batchCode;
            Quantity = quantity;
            TaskId = taskId;
            IsActive = true;
        }

        public string BatchCode { get; private set; }

        public int Quantity { get; private set; }

        public bool IsActive { get; set; }

        public long TaskId { get; private set; }
        public ManufacturingTask Task { get; set; }

        public string QcCardId { get; set; }
        public QcCard QcCard { get; set; }

        public string CertificateId { get; set; }
        public Certificate Certificate { get; set; }

        public ICollection<DingZhiDan> DingZhiDanes { get; set; } = new List<DingZhiDan>();
    }

    public class TransferList : CreationAuditedAggregateRoot, IReceptionAudited
    {
        public bool IsReceived { get; set; }
        public DateTime ReceptionTime { get; set; }
        public long? RecipientUserId { get; set; }

        public ICollection<TransferRecord> Records { get; set; } = new List<TransferRecord>();
    }

    public class TransferRecord : Entity, IReceptionAudited
    {
        public bool IsReceived { get; set; }
        public DateTime ReceptionTime { get; set; }
        public long? RecipientUserId { get; set; }
    }
}