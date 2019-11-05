using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CentersFrontier.Production.Roles.Dto;
using CentersFrontier.Production.Users.Dto;

namespace CentersFrontier.Production.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
