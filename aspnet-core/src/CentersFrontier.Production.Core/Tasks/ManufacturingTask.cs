using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using CentersFrontier.Production.Entities;

namespace CentersFrontier.Production.Tasks
{
    public abstract class ManufacturingTask : FullAuditedEntity<long>, IReceptionAudited, IPassivable
    {
        protected ManufacturingTask(string taskCode, string drawingCode, string drawingName, int totalQuantity, int manufacturerId)
        {
            TaskCode = taskCode;
            DrawingCode = drawingCode;
            DrawingName = drawingName;
            TotalQuantity = totalQuantity;
            ManufacturerId = manufacturerId;
            NextBatchSequence = 1;
            IsActive = false;
        }

        public string TaskCode { get; protected set; }

        public string DrawingCode { get; set; }

        public string DrawingName { get; set; }

        public int TotalQuantity { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public bool IsReceived { get; set; }
        public DateTime ReceptionTime { get; set; }
        public long? RecipientUserId { get; set; }

        public int NextBatchSequence { get; set; }

        public bool IsActive { get; set; }

        public ICollection<ManufacturingBatch> Batches { get; set; }

        public virtual void ChangeTaskCode(string newTaskCode)
        {
            TaskCode = newTaskCode;
        }

        public string NextBatchCode()
        {
            return TaskCode + ProductionConsts.BatchJoiner + NextBatchSequence.ToString("D3");
        }

        public void GoProduction(int quantity)
        {
            var batch = new ManufacturingBatch(NextBatchCode(), quantity);
            Batches.Add(batch);
            NextBatchSequence++;
        }
    }

    //public class ManufacturingTask<TDrawing> : ManufacturingTask where TDrawing : Drawing, new()
    //{
    //    public ManufacturingTask(string taskCode, string drawingCode, string drawingName, int totalQuantity, Manufacturer manufacturer)
    //        : base(taskCode, drawingCode, drawingName, totalQuantity, manufacturer)
    //    {
    //    }

    //    public TDrawing Drawing { get; set; }
    //}
}