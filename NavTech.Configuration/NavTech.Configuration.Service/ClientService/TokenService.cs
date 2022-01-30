using NavTech.Configuration.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NavTech.Configuration.Service.ClientService
{
    public class TokenService : ITokenService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TokenService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> GetAuthToken(BaseOptionModel baseOptionModel)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("grant_type", "client_credentials");
            dict.Add("client_id", baseOptionModel.ClientId);
            dict.Add("client_secret", baseOptionModel.Client_Secret);
            dict.Add("resource", baseOptionModel.Resource);

            var data = new FormUrlEncodedContent(dict);
            var tokenClient = _httpClientFactory.CreateClient("TokenClient");

            var response = await tokenClient.PostAsync(baseOptionModel.TokenEndPoint, data);
            var resultContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IDictionary<string, string>>(resultContent);
            return result["access_token"];
        }
    }
}
