using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Extensions;
using Abp.UI;

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
}