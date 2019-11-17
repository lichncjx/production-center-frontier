namespace CentersFrontier.Production.Tasks
{
    public class SideTask : ManufacturingTask
    {
        public SideTask(string taskCode, string drawingCode, string drawingName, int totalQuantity, int manufacturerId)
            : base(taskCode, drawingCode, drawingName, totalQuantity, manufacturerId)
        {
        }

        public SideTask(string taskCode, string drawingCode, string drawingName, int totalQuantity, int manufacturerId, long originalBatchId)
            : this(taskCode, drawingCode, drawingName, totalQuantity, manufacturerId)
        {
            OriginalBatchId = originalBatchId;
        }

        public long OriginalBatchId { get; set; }
        public ManufacturingBatch OriginalBatch { get; set; }
    }
}