using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using CentersFrontier.Production.Configuration;
using CentersFrontier.Production.Web;

namespace CentersFrontier.Production.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ProductionDbContextFactory : IDesignTimeDbContextFactory<ProductionDbContext>
    {
        public ProductionDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProductionDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ProductionDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ProductionConsts.ConnectionStringName));

            return new ProductionDbContext(builder.Options);
        }
    }
}
