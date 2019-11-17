namespace CentersFrontier.Production.Tasks
{
    public class SubTask : ManufacturingTask
    {
        public SubTask(string taskCode, string drawingCode, string drawingName, int totalQuantity, int manufacturerId)
            : base(taskCode, drawingCode, drawingName, totalQuantity, manufacturerId)
        {
            IsActive = true;
        }

        public long MainTaskId { get; set; }

        public MainTask MainTask { get; set; }

        public override void ChangeTaskCode(string newTaskCode)
        {
            //todo:
        }
    }
}