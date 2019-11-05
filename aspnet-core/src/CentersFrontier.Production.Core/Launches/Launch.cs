using System;
using CentersFrontier.Production.Entities;
using CentersFrontier.Production.Models;
using CentersFrontier.Production.Tasks;

namespace CentersFrontier.Production.Launches
{
    /// <summary>
    /// 发次
    /// </summary>
    public class Launch : SimpleCndEntity
    {
        public string ModelCode { get; set; }
        public Model Model { get; set; }

        public DevelopmentStage Stage { get; set; }

        //专用任务分类
        public string SpecialClassificationId { get; set; }
        public TaskClassification SpecialClassification { get; set; }

        //通用任务分类
        public string UniversalClassificationId { get; set; }
        public TaskClassification UniversalClassification { get; set; }


        public DateTime PlannedCompletionDate { get; set; }
        public DateTime PlannedFinishDate { get; set; }
        public DateTime PlannedDeliveryDate { get; set; }
        public int CompletionPriority { get; set; }
    }

    /// <summary>
    /// 批次
    /// </summary>
    public class Bundle : SimpleCndEntity
    {
        //todo: 还没搞清楚到底是什么概念
    }
}