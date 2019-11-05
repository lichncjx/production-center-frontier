using System.Threading.Tasks;
using CentersFrontier.Production.Configuration.Dto;

namespace CentersFrontier.Production.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
