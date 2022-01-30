using System.Collections.Generic;
using System.Threading.Tasks;

namespace NavTech.Configuration.Service.ClientService
{
    public interface IHttpClientService
    {
        Task<List<string>> GetMerchantFields();
        Task<List<string>> GetCustomerReviewFields();
    }
}
