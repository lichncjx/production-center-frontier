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
        public ProductionTask(string taskCode, string drawingCode, Workshop mainWorkshop)
        {
            TaskCode = taskCode;
            DrawingCode = drawingCode;
            MainWorkshop = mainWorkshop;
            SetClassification();
        }

        public string TaskCode { get; private set; }

        public string DrawingCode { get; private set; }

        public Workshop MainWorkshop { get; private set; }

        public string Classification { get; set; }
        //[ForeignKey("Classification")]
        //public TaskClassification Classification { get; set; }

        private void SetClassification()
        {
            if (TaskCode.IsNullOrWhiteSpace()) throw new ApplicationException("任务号不能为空");
            try
            {
                Classification = TaskCode.Split('-')[0];
            }
            catch (Exception e)
            {
                throw new UserFriendlyException($"任务号解析错误，检查任务号格式。{e.Message}");
            }
        }

        public void ChangeTaskCode(string newTaskCode)
        {
            TaskCode = newTaskCode;
            SetClassification();
        }

        public void ChangeDrawingCode(string newDrawingCode)
        {
            DrawingCode = newDrawingCode;
        }

        public void ChangeMainWorkshop(Workshop newWorkshop)
        {
            MainWorkshop = newWorkshop;
        }
    }

    public class ProductionTask<TDrawing> : ProductionTask where TDrawing : Drawing, new()
    {
        public ProductionTask(string taskCode, string drawingCode, Workshop mainWorkshop)
            : base(taskCode, drawingCode, mainWorkshop)
        {
        }

        public TDrawing Drawing { get; set; }
    }
}