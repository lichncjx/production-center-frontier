using Abp.Application.Services.Dto;

namespace CentersFrontier.Production.Batches.Dto
{
    public class PrepareForDeliveryInput : EntityDto<long>
    {
        public int DestinationId { get; set; }
    }
}