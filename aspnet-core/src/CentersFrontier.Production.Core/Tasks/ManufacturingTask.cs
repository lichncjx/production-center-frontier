using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Extensions;
using Abp.UI;
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

        public bool IsActive { get; set; }

        public ICollection<ManufacturingBatch> Batches { get; set; }

        public virtual void ChangeTaskCode(string newTaskCode)
        {
            TaskCode = newTaskCode;
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

    public class MainTask : ManufacturingTask
    {
        public MainTask(string taskCode, string drawingCode, string drawingName, int totalQuantity, int manufacturerId)
            : base(taskCode, drawingCode, drawingName, totalQuantity, manufacturerId)
        {
            ClassificationId = ParseClassificationId(TaskCode);
        }

        public string ClassificationId { get; private set; }

        public ICollection<SubTask> SubTasks { get; set; } = new List<SubTask>();

        public bool HasSubTasks => SubTasks.Any();

        public override void ChangeTaskCode(string newTaskCode)
        {
            base.ChangeTaskCode(newTaskCode);
            ClassificationId = ParseClassificationId(TaskCode);
            foreach (var subTask in SubTasks) subTask.ChangeTaskCode(newTaskCode);
        }

        /// <summary>
        /// 通过任务号解析任务分类，即第一个‘-’前面的内容。
        /// </summary>
        /// <param name="taskCode">任务号</param>
        /// <returns>任务分类</returns>
        public static string ParseClassificationId(string taskCode)
        {
            if (taskCode.IsNullOrWhiteSpace()) throw new ArgumentNullException(nameof(taskCode));
            try
            {
                return taskCode.Split('-')[0];
            }
            catch (Exception e)
            {
                throw new UserFriendlyException($"任务号解析错误，检查任务号格式。{e.Message}");
            }
        }
    }


    public class SubTask : ManufacturingTask
    {
        public SubTask(string taskCode, string drawingCode, string drawingName, int totalQuantity, int manufacturerId)
            : base(taskCode, drawingCode, drawingName, totalQuantity, manufacturerId)
        {
            IsActive = true;
        }

        public long MainTaskId { get; set; }

        public MainTask MainTask { get; set; }


        public override void ChangeTaskCode(string newTaskCode)
        {
            //todo:
        }
    }

    public class SideTask : ManufacturingTask
    {
        public SideTask(string taskCode, string drawingCode, string drawingName, int totalQuantity, int manufacturerId, long originalBatchId)
            : base(taskCode, drawingCode, drawingName, totalQuantity, manufacturerId)
        {
            OriginalBatchId = originalBatchId;
        }

        public long OriginalBatchId { get; set; }
        public ManufacturingBatch OriginalBatch { get; set; }
    }
}