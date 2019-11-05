using Xunit;

namespace CentersFrontier.Production.Tests
{
    public sealed class MultiTenantFactAttribute : FactAttribute
    {
        public MultiTenantFactAttribute()
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (!ProductionConsts.MultiTenancyEnabled)
            {
                Skip = "MultiTenancy is disabled.";
            }
        }
    }
}
