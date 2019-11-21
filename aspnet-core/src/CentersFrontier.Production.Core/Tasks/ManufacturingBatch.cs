using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Abp.UI;
using Castle.Core.Internal;
using CentersFrontier.Production.Quality;

namespace CentersFrontier.Production.Tasks
{
    public class ManufacturingBatch : FullAuditedAggregateRoot<long>, IPassivable
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

        public bool IsCompleted { get; set; }

        public DateTime CompletionTime { get; set; }

        public bool ExceptionalPass { get; set; }

        public long TaskId { get; private set; }
        public ManufacturingTask Task { get; set; }

        public long ParentId { get; set; }
        public ManufacturingBatch Parent { get; set; }
        public int ParentQuantity { get; set; }


        public string QcCardId { get; set; }
        public QcCard QcCard { get; set; }

        public string CertificateId { get; set; }
        public Certificate Certificate { get; set; }

        /// <summary>
        /// 交接记录，仅指完工交接。
        /// </summary>
        public DeliveryRecord DeliveryRecord { get; set; }

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

        public void PrepareForDelivery(int destinationId)
        {
            if (CertificateId.IsNullOrEmpty())
                if (!ExceptionalPass)
                    throw new UserFriendlyException("只有已开具合格证的任务才能进行交接");
            DeliveryRecord = new DeliveryRecord
            {
                DestinationId = destinationId,
                TaskId = TaskId
            };
        }

        public void Complete()
        {
            if (IsCompleted)
                throw new ApplicationException("该批次已经完成");

            IsCompleted = true;
            CompletionTime = Clock.Now;
        }
    }
}