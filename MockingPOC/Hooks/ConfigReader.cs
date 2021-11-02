using Microsoft.Extensions.Configuration;

namespace MockingPOC.Hooks
{
    public class ConfigReader
    {
        public static IConfigurationRoot Endpoint = GetEndpoint();

        private static IConfigurationRoot GetEndpoint()
        {
            return new ConfigurationBuilder().AddJsonFile("Hooks//Endpoints//RoyalboxEndpoints.json").Build();
        }

        

    }
}