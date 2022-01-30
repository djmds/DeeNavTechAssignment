using NavTech.Configuration.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NavTech.Configuration.Repository.IRepository
{
    public interface IConfigurationRepository
    {
        Task<List<EntityConfiguration>> GetEntityConfigurations(string entityName, List<string> fieldsName, string sourceType);
        Task CreateEntityConfiguration(List<EntityConfiguration> entityConfigurations);
    }
}
