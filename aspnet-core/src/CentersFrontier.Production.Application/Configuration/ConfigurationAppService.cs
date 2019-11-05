using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CentersFrontier.Production.Configuration.Dto;

namespace CentersFrontier.Production.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ProductionAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
