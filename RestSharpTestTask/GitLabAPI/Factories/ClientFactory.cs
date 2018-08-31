using RestSharp;

namespace GitLabAPI.Factories
{
    public class CreateClient
    {
        public static RestClient GetNewClient(string url) => new RestClient(url);
    }
}