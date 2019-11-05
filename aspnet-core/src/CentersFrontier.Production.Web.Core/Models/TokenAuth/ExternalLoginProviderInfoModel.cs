using Abp.AutoMapper;
using CentersFrontier.Production.Authentication.External;

namespace CentersFrontier.Production.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
