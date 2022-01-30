using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NavTech.Configuration.DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ConfigurationContext>
    {
        public ConfigurationContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                .AddJsonFile("appsettings.json", optional: true).Build();

            var builder = new DbContextOptionsBuilder<ConfigurationContext>();
            var connectionString = configuration.GetConnectionString("ConfigurationContext");
            builder.UseSqlServer(connectionString);
            return new ConfigurationContext(builder.Options);
        }
    }
}
