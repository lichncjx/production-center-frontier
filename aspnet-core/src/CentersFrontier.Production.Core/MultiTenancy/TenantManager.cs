using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using CentersFrontier.Production.Authorization.Users;
using CentersFrontier.Production.Editions;

namespace CentersFrontier.Production.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
