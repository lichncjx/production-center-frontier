using System.Threading.Tasks;
using Abp.Application.Services;
using CentersFrontier.Production.Sessions.Dto;

namespace CentersFrontier.Production.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
