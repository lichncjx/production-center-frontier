using Abp.Events.Bus;
using Abp.Events.Bus.Entities;

namespace CentersFrontier.Production.Tasks.Events
{
    public class BatchCompleted : EventData
    {
        public long BatchId { get; set; }
    }
}