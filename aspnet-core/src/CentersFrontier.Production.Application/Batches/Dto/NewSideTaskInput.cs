using Abp.Application.Services.Dto;

namespace CentersFrontier.Production.Batches.Dto
{
    public class NewSideTaskInput : EntityDto<long>
    {
        public string DrawingCode { get; set; }
        public string DrawingName { get; set; }
        public int Quantity { get; set; }
        public int ManufacturingId { get; set; }
    }
}