using Abp.Application.Services.Dto;

namespace CentersFrontier.Production.Batches.Dto
{
    public class PrepareForTransferInput : EntityDto<long>
    {
        public int DestinationId { get; set; }
    }
}