using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using CentersFrontier.Production.Quality;

namespace CentersFrontier.Production.Tasks
{
    public class ManufacturingBatch : FullAuditedEntity<long>, IPassivable
    {
        public ManufacturingBatch(string batchCode, int quantity)
        {
            BatchCode = batchCode;
            Quantity = quantity;
            NextSideTaskSequence = 1;
            IsActive = true;
        }

        public ManufacturingBatch(string batchCode, int quantity, long taskId)
            : this(batchCode, quantity)
        {
            TaskId = taskId;
        }

        public string BatchCode { get; private set; }

        public int Quantity { get; private set; }

        public int NextSideTaskSequence { get; set; }

        public bool IsActive { get; set; }

        public long TaskId { get; private set; }
        public ManufacturingTask Task { get; set; }

        public long ParentId { get; set; }
        public ManufacturingBatch Parent { get; set; }
        public int ParentQuantity { get; set; }


        public string QcCardId { get; set; }
        public QcCard QcCard { get; set; }

        public string CertificateId { get; set; }
        public Certificate Certificate { get; set; }

        public ICollection<SideTask> SideTasks { get; set; } = new List<SideTask>();

        public string NextSideTaskCode()
        {
            return BatchCode + ProductionConsts.SideTaskJoiner + NextSideTaskSequence.ToString("D");
        }

        public void NewSideTask(string drawingCode, string drawingName, int quantity, int manufacturerId)
        {
            var sideTask = new SideTask(NextSideTaskCode(), drawingCode, drawingName, quantity, manufacturerId);
            SideTasks.Add(sideTask);
            NextSideTaskSequence++;
        }
    }
}