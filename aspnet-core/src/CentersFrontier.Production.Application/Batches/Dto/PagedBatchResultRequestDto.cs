using Abp.Application.Services.Dto;

namespace CentersFrontier.Production.Batches.Dto
{
    public class PagedBatchResultRequestDto : PagedResultRequestDto
    {
        public bool IsActive { get; set; }

        public bool IsDelivered { get; set; }

        public bool HasCertificateId { get; set; }

        public int ManufacturerId { get; set; }
    }
}