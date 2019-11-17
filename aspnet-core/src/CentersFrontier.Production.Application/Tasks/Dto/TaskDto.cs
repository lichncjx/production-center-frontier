using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CentersFrontier.Production.Tasks.Dto
{
    [AutoMap(typeof(MainTask), typeof(SideTask))]
    public class TaskDto : EntityDto<long>
    {
        [Required]
        public string TaskCode { get; set; }

        [Required]
        public string DrawingCode { get; set; }

        [Required]
        public string DrawingName { get; set; }

        public int TotalQuantity { get; set; }

        public int ManufacturerId { get; set; }

        public long OriginalBatchId { get; set; }
    }
}