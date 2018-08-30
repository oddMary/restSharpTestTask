using RestSharp;

namespace GitLabAPI.Client
{
    public class CreateClient
    {
        public static RestClient GetNewClient(string url) => new RestClient(url);
    }
}