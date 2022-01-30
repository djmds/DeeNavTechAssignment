using Microsoft.EntityFrameworkCore;
using NavTech.Configuration.DataAccess.Models;

namespace NavTech.Configuration.DataAccess
{
    public class ConfigurationContext : DbContext
    {
        public ConfigurationContext(DbContextOptions<ConfigurationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EntityConfiguration> EntityConfigurations { get; set; }
    }
}
