using GitLabAPI.Tool;
using RestSharp;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.Factories
{
    public class ClientFactory
    {
        private static readonly Logger _logger = new Logger(typeof(ClientFactory));

        private static ClientFactory instance;
        private RestClient Client;

        private ClientFactory()
        {
            _logger.Info($"New client {BASE_URL} created");
            Client = new RestClient(BASE_URL);
        }

        public static RestClient GetInstance()
        {
            if (instance == null)
                instance = new ClientFactory();
            return instance.Client;
        }
    }
}