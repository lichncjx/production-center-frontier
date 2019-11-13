using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace CentersFrontier.Production.Tasks
{
    public class ManufacturingBatch : CreationAuditedEntity
    {
        public ManufacturingBatch(string batchCode, int quantity, long taskId)
        {
            BatchCode = batchCode;
            Quantity = quantity;
            TaskId = taskId;
        }

        public string BatchCode { get; private set; }
        public int Quantity { get; private set; }
        public string QcCard { get; set; }

        public long TaskId { get; private set; }
        public ManufacturingTask Task { get; set; }

        public ICollection<DingZhiDan> DingZhiDanes { get; set; } = new List<DingZhiDan>();
    }

    public class DingZhiDan : CreationAuditedEntity, IReceptionAudited
    {
        public DingZhiDan(long batchId, string batchCode, string drawingCode, string drawingName, int quantity,
            Manufacturer zhuZhi, Manufacturer fuZhi)
        {
            BatchId = batchId;
            BatchCode = batchCode;
            DrawingCode = drawingCode;
            DrawingName = drawingName;
            Quantity = quantity;
            ZhuZhi = zhuZhi;
            FuZhi = fuZhi;
        }

        public Manufacturer ZhuZhi { get; private set; }
        public Manufacturer FuZhi { get; private set; }
        public long BatchId { get; private set; }
        public string BatchCode { get; private set; }
        public string DrawingCode { get; set; }
        public string DrawingName { get; set; }
        public int Quantity { get; set; }
        public DateTime ReceptionTime { get; set; }
        public long? RecipientUserId { get; set; }
    }

    public class TransferList : CreationAuditedAggregateRoot, IReceptionAudited
    {
        public DateTime ReceptionTime { get; set; }
        public long? RecipientUserId { get; set; }

        public ICollection<TransferRecord> Records { get; set; } = new List<TransferRecord>();
    }

    public class TransferRecord : Entity, IReceptionAudited
    {
        public DateTime ReceptionTime { get; set; }
        public long? RecipientUserId { get; set; }
    }

    public interface IHasReceptionTime
    {
        DateTime ReceptionTime { get; set; }
    }
    public interface IReceptionAudited : IHasReceptionTime
    {
        long? RecipientUserId { get; set; }
    }

}