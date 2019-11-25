using Abp.Events.Bus;

namespace CentersFrontier.Production.Tasks.Events
{
    public class TaskCompleted : EventData
    {
        public TaskCompleted(long taskId)
        {
            TaskId = taskId;
        }

        public long TaskId { get; set; }
    }

    public class MainTaskCompleted : TaskCompleted
    {
        public MainTaskCompleted(long taskId) : base(taskId)
        {
        }
    }

    public class SideTaskCompleted : TaskCompleted
    {
        public SideTaskCompleted(long taskId, long originalBatchId) : base(taskId)
        {
            OriginalBatchId = originalBatchId;
        }

        public long OriginalBatchId { get; set; }
    }
}