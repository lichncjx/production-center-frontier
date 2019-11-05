using System;
using CentersFrontier.Production.Entities;
using CentersFrontier.Production.Models;
using CentersFrontier.Production.Tasks;

namespace CentersFrontier.Production.Launches
{
    public class Launch : SimpleCndEntity
    {
        public string ModelCode { get; set; }
        public Model Model { get; set; }

        public string SpecialClassificationId { get; set; }
        public TaskClassification SpecialClassification { get; set; }

        public string UniversalClassificationId { get; set; }
        public TaskClassification UniversalClassification { get; set; }

        public DevelopmentStage Stage { get; set; }
        public DateTime PlannedCompletionDate { get; set; }
        public DateTime PlannedFinishDate { get; set; }
        public DateTime PlannedDeliveryDate { get; set; }
        public int CompletionPriority { get; set; }
    }

    public class Bundle : SimpleCndEntity
    {

    }
}