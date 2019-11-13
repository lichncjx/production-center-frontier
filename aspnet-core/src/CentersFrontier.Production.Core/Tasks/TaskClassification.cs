using System.Collections.Generic;
using Abp.Domain.Entities;

namespace CentersFrontier.Production.Tasks
{
    /// <summary>
    /// 任务分类
    /// </summary>
    public class TaskClassification : Entity<string>
    {
        public bool IsUniversal { get; set; }

        public ICollection<ManufacturingTask> Tasks { get; set; }
    }
}