using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CentersFrontier.Production.Configuration;

namespace CentersFrontier.Production.Web.Host.Startup
{
    [DependsOn(
       typeof(ProductionWebCoreModule))]
    public class ProductionWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ProductionWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ProductionWebHostModule).GetAssembly());
        }
    }
}
