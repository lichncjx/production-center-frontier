using System.Threading.Tasks;
using Abp.Application.Services;
using CentersFrontier.Production.Authorization.Accounts.Dto;

namespace CentersFrontier.Production.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
