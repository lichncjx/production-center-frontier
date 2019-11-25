using System;
using Abp.Extensions;
using Abp.UI;
using CentersFrontier.Production.Tasks.Events;

namespace CentersFrontier.Production.Tasks
{
    public class MainTask : ManufacturingTask
    {
        public MainTask(string taskCode, string drawingCode, string drawingName, int totalQuantity, int manufacturerId)
            : base(taskCode, drawingCode, drawingName, totalQuantity, manufacturerId)
        {
            ClassificationId = ParseClassificationId(TaskCode);
        }

        public string ClassificationId { get; private set; }

        public override void ChangeTaskCode(string newTaskCode)
        {
            base.ChangeTaskCode(newTaskCode);
            ClassificationId = ParseClassificationId(TaskCode);
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

        public override void Complete()
        {
            base.Complete();
            DomainEvents.Add(new MainTaskCompleted(Id));
        }
    }
}