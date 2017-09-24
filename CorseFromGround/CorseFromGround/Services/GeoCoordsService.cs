using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CorseFromGround.Services
{
    public class GeoCoordsService
    {
        private ILogger<GeoCoordsService> logger;
        private IConfigurationRoot config;

        public GeoCoordsService(ILogger<GeoCoordsService> logger, IConfigurationRoot config)
        {
            this.config = config;
            this.logger = logger;
        }

        public async Task<GeoCorrdsResult> GetCoordsAsync(string name)
        {
            var result = new GeoCorrdsResult()
            {
                Success = false,
                Message = "failed"
            };

            var apiKey = this.config["Keys:BingKey"];
            var encodename = WebUtility.UrlEncode(name);
            var url = $"http://dev.virtualearth.net/REST/v1/Locations?q={encodename}&key={apiKey}";
            using (var client = new HttpClient())
            {

            }

                return result;
        }
    }
}
