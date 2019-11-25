using Abp.Application.Services.Dto;

namespace CentersFrontier.Production.Batches.Dto
{
    public class ConfirmDeliveryInput : EntityDto<long>
    {
        public string Remark { get; set; }
    }
}