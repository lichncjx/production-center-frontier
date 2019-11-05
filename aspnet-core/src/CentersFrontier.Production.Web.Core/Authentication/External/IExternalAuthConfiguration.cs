using System.Collections.Generic;

namespace CentersFrontier.Production.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
