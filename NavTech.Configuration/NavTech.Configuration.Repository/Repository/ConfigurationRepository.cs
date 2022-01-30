using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NavTech.Configuration.Common;
using NavTech.Configuration.DataAccess;
using NavTech.Configuration.DataAccess.Models;
using NavTech.Configuration.Repository.IRepository;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NavTech.Configuration.Repository.Repository
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ConfigurationContext _configurationContext;

        public ConfigurationRepository(ConfigurationContext configurationContext)
        {
            _configurationContext = configurationContext;
        }

        public async  Task CreateEntityConfiguration(List<EntityConfiguration> entityConfigurations)
        {
            var dtBulkInsertUpdateEntity = entityConfigurations.ToDataTable();
            var tblBulkInsertUpdateEntityParameter = new SqlParameter("tblBulkInsertUpdateEntityType", SqlDbType.Structured)
            {
                TypeName = "dbo.BulkInsertUpdateEntityConfigurationType",
                Value = dtBulkInsertUpdateEntity
            };
            await _configurationContext.Database.ExecuteSqlRawAsync("EXEC spBulkInsertUpdateEntityConfiguration @tblBulkInsertUpdateEntityType", tblBulkInsertUpdateEntityParameter);
        }

        public Task<List<EntityConfiguration>> GetEntityConfigurations(string entityName, List<string> fieldsName, string sourceType)
        {
            return _configurationContext.EntityConfigurations.Where(a => a.EntityName == entityName && a.FieldSource == sourceType
            && fieldsName.Contains(a.FieldName)).ToListAsync();
        }
    }
}
