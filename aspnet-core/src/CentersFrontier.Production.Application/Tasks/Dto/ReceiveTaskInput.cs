using Abp.Application.Services.Dto;

namespace CentersFrontier.Production.Tasks.Dto
{
    public class ReceiveTaskInput : EntityDto<long>
    {
        public long UserId { get; set; }
    }
}