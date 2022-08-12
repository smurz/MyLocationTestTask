using System;
using System.Net.Http;
using System.Threading.Tasks;
using MyLocation.Services.Dto;
using MyLocation.Services.Interfaces;
using Newtonsoft.Json;

namespace MyLocation.Services
{
    public class IpApiLocationService : ILocationService
    {
        private readonly string _apiUrl;

        public IpApiLocationService(string apiUrl)
        {
            _apiUrl = apiUrl ?? throw new ArgumentNullException(nameof(apiUrl));
        }

        public async Task<string?> GetCurrentLocationAsync()
        {
            using var httpClient = new HttpClient();

            var strResponse = await httpClient.GetStringAsync(_apiUrl);
            var apiResponse = JsonConvert.DeserializeObject<IpApiResponse>(strResponse);
            return apiResponse?.Country;
        }


    }
}
