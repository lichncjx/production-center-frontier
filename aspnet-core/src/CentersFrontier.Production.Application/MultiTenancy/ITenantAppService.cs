using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CentersFrontier.Production.MultiTenancy.Dto;

namespace CentersFrontier.Production.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

