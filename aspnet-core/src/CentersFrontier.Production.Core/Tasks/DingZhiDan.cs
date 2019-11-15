using System;
using Abp.Domain.Entities.Auditing;
using CentersFrontier.Production.Entities;

namespace CentersFrontier.Production.Tasks
{
    /// <summary>
    /// 定制单，对应一项定制任务。
    /// </summary>
    public class DingZhiDan : CreationAuditedEntity, IReceptionAudited
    {

        public long BatchId { get; set; }
        public string TaskCode { get; set; }
        public string DrawingCode { get; set; }
        public string DrawingName { get; set; }
        public int Quantity { get; set; }
        public Manufacturer ZhuZhi { get; set; }
        public Manufacturer FuZhi { get; set; }

        public bool IsReceived { get; set; }
        public DateTime ReceptionTime { get; set; }
        public long? RecipientUserId { get; set; }
    }

    /// <summary>
    /// 任务单，对应一条主任务。
    /// </summary>
    public class RenWuDan : CreationAuditedEntity, IReceptionAudited
    {
        public string TaskCode { get; set; }
        public string DrawingCode { get; set; }
        public string DrawingName { get; set; }
        public int TotalQuantity { get; set; }
        public Manufacturer ZhuZhi { get; set; }


        public bool IsReceived { get; set; }
        public DateTime ReceptionTime { get; set; }
        public long? RecipientUserId { get; set; }
    }
}