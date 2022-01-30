using AutoMapper;
using NavTech.Configuration.Common;
using NavTech.Configuration.DataAccess.Models;
using NavTech.Configuration.Models.ResponseModels;
using NavTech.Configuration.Repository.IRepository;
using NavTech.Configuration.Service.ClientService;
using NavTech.Configuration.Service.IServiceContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NavTech.Configuration.Service.ServiceImplementations
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IMapper _mapper;
        private readonly IConfigurationRepository _configurationRepository;
        public ConfigurationService(IHttpClientService httpClientService,IMapper mapper, IConfigurationRepository configurationRepository)
        {
            _httpClientService = httpClientService;
            _mapper = mapper;
            _configurationRepository = configurationRepository;
        }

        public async  Task CreateConfiguration(EntityModel entityModel)
        {
            var entityConfigurationList = _mapper.Map<List<EntityConfiguration>>(entityModel.Fields, 
                opt => opt.AfterMap((s,d)
                =>
            { 
               foreach(var i in d)
                {
                    i.EntityName = entityModel.EntityName;
                }
            }));
            await _configurationRepository.CreateEntityConfiguration(entityConfigurationList);
        }

        public async Task<EntityConfigurationModel> GetConfiguration(string entityType)
        {
            var merchantFields = await _httpClientService.GetMerchantFields();
            var merchantConfigurations = await _configurationRepository.GetEntityConfigurations(entityType, merchantFields, nameof(SourceTypeEnum.Merchant));
            var merchantfieldList = _mapper.Map<List<FieldModel>>(merchantConfigurations);

            var customerReviewFields = await _httpClientService.GetCustomerReviewFields();
            var customerConfigurations = await _configurationRepository.GetEntityConfigurations(entityType, customerReviewFields, nameof(SourceTypeEnum.CustomerReview));
            var customerReviewfieldList = _mapper.Map<List<FieldModel>>(customerConfigurations);

            EntityConfigurationModel entityConfigurationModel = new EntityConfigurationModel();
            entityConfigurationModel.Entities = new List<EntityModel>();
            entityConfigurationModel.Entities.Add(new EntityModel { EntityName = entityType, 
                Fields = merchantfieldList
            });
            entityConfigurationModel.Entities.Add(new EntityModel
            {
                EntityName = entityType,
                Fields = customerReviewfieldList
            });
            return entityConfigurationModel;
        }
    }
}
