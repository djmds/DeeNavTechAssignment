using Microsoft.Extensions.Configuration;
using NavTech.Configuration.Common;
using NavTech.Configuration.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NavTech.Configuration.Service.ClientService
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly MerchantOption _merchantOption;
        private readonly CustomerReviewOption _customerReviewOption;
        private readonly ITokenService _tokenService;

        public HttpClientService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ITokenService tokenService)
        {
            _httpClientFactory = httpClientFactory;
             _merchantOption = new MerchantOption(); 
            configuration.GetSection(nameof(SourceTypeEnum.Merchant)).Bind(_merchantOption);
            _customerReviewOption = new CustomerReviewOption();
            configuration.GetSection(nameof(SourceTypeEnum.CustomerReview)).Bind(_customerReviewOption);
            _tokenService = tokenService;
        }
        public async Task<List<string>> GetMerchantFields()
        {
            List<string> merchantFields = null;
            var merchantClient = _httpClientFactory.CreateClient(nameof(SourceTypeEnum.Merchant));
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.RequestUri = new Uri(_merchantOption.BaseAddress + _merchantOption.Path);
            var token = await _tokenService.GetAuthToken(_merchantOption);
            httpRequestMessage.Headers.Add("Authorization", "Bearer " + token);

            var merchantResponse = await merchantClient.SendAsync(httpRequestMessage);
            if(merchantResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                merchantFields = new List<string>();
                var strArr = (await merchantResponse.Content.ReadAsStringAsync())?.Split(",");
                foreach(var item in strArr)
                {
                    merchantFields.Add(item.Trim(' '));
                }
            }
            return merchantFields;
        }

        public async Task<List<string>> GetCustomerReviewFields()
        {
            List<string> customerReviewFields = null;
            var customerReviewClient = _httpClientFactory.CreateClient(nameof(SourceTypeEnum.CustomerReview));
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.RequestUri = new Uri(_customerReviewOption.BaseAddress + _customerReviewOption.Path);
            var token = await _tokenService.GetAuthToken(_customerReviewOption);
            httpRequestMessage.Headers.Add("Authorization", "Bearer " + token);

            var customerReviewResponse = await customerReviewClient.SendAsync(httpRequestMessage);
            if (customerReviewResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                customerReviewFields = new List<string>();
                var strArr = (await customerReviewResponse.Content.ReadAsStringAsync())?.Split(",");
                foreach (var item in strArr)
                {
                    customerReviewFields.Add(item.Trim(' '));
                }
            }
            return customerReviewFields;
        }
    }
}
