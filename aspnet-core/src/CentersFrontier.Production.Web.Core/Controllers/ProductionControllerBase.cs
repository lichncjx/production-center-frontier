using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CentersFrontier.Production.Controllers
{
    public abstract class ProductionControllerBase: AbpController
    {
        protected ProductionControllerBase()
        {
            LocalizationSourceName = ProductionConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
