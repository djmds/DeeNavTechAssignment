using NavTech.Configuration.Models.ResponseModels;
using System.Threading.Tasks;

namespace NavTech.Configuration.Service.IServiceContracts
{
    public interface IConfigurationService
    {
        Task<EntityConfigurationModel> GetConfiguration(string entityType);
        Task CreateConfiguration(EntityModel entityModel);
    }
}
