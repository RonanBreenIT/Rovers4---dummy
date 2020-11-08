using Microsoft.Extensions.Configuration;
using System;


namespace Rovers4.Services
{
    public interface IMapsService
    {
        string GetApiKey();
    }

    public class MapsService : IMapsService
    {
        private readonly IConfiguration _configuration;

        public MapsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetApiKey()
        {
            var ApiKey = _configuration["GoogleMapsApiKey"];
            return ApiKey;
        }
    }
}
