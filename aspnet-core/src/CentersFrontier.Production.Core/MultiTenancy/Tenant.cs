using Abp.MultiTenancy;
using CentersFrontier.Production.Authorization.Users;

namespace CentersFrontier.Production.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
