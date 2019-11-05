using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CentersFrontier.Production.Authorization;

namespace CentersFrontier.Production
{
    [DependsOn(
        typeof(ProductionCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ProductionApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ProductionAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ProductionApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
