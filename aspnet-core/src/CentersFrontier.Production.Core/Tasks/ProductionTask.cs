using System;
using Abp.Domain.Entities;
using Abp.Extensions;
using Abp.UI;
using CentersFrontier.Production.Drawings;
using CentersFrontier.Production.Workshops;

namespace CentersFrontier.Production.Tasks
{
    public class ProductionTask : Entity<long>
    {
        public ProductionTask(string taskCode, string drawingCode, string drawingName, Workshop mainWorkshop)
        {
            TaskCode = taskCode;
            DrawingCode = drawingCode;
            DrawingName = drawingName;
            MainWorkshop = mainWorkshop;
            ClassificationId = ParseClassificationId(TaskCode);
        }

        public string TaskCode { get; private set; }

        public string DrawingCode { get; set; }

        public string DrawingName { get; set; }

        public Workshop MainWorkshop { get; private set; }

        public string ClassificationId { get; private set; }
        //[ForeignKey("ClassificationId")]
        //public TaskClassification Classification { get; set; }

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

        public void ChangeTaskCode(string newTaskCode)
        {
            TaskCode = newTaskCode;
            ClassificationId = ParseClassificationId(TaskCode);
        }

        public void ChangeMainWorkshop(Workshop newWorkshop)
        {
            MainWorkshop = newWorkshop;
        }
    }

    public class ProductionTask<TDrawing> : ProductionTask where TDrawing : Drawing, new()
    {
        public ProductionTask(string taskCode, string drawingCode, string drawingName, Workshop mainWorkshop)
            : base(taskCode, drawingCode, drawingName, mainWorkshop)
        {
        }

        public TDrawing Drawing { get; set; }
    }
}