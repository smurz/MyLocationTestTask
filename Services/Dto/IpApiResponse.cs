using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyLocation.Services.Dto
{

    [JsonObject]
    public class IpApiResponse
    {
        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("countryCode")]
        public string? CountryCode { get; set; }

        [JsonProperty("region")]
        public string? Region { get; set; }

        [JsonProperty("regionName")]
        public string? RegionName { get; set; }

        [JsonProperty("city")]
        public string? City { get; set; }

        [JsonProperty("zip")]
        public string? Zip { get; set; }

        [JsonProperty("lat")]
        public float? Lat { get; set; }

        [JsonProperty("lon")]
        public float? Lon { get; set; }

        [JsonProperty("timezone")]
        public string? Timezone { get; set; }

        [JsonProperty("isp")]
        public string? Isp { get; set; }

        [JsonProperty("org")]
        public string? Org { get; set; }

        [JsonProperty("as")]
        public string? As { get; set; }

        [JsonProperty("query")]
        public string? Query { get; set; }
    }
}
