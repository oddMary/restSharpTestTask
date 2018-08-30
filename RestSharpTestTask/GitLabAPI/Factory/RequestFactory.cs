using GitLabAPI.enums;
using RestSharp;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.Factories
{
    public class RequestFactory
    {
        public int projectId = 10;

        public static RestRequest GetNameSpacesRequestWithPrivateTokenHeader()
        {
            RestRequest RestRequest = new RestRequest(RequestUrlParameters.namespaces.ToString());
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            RestRequest.Method = Method.GET;
            return RestRequest;
        }

        public static RestRequest PostProjectRequestWithPrivateTokenHeader()
        {
            RestRequest RestRequest = new RestRequest(RequestUrlParameters.projects.ToString());
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            RestRequest.Method = Method.POST;
            return RestRequest;
        }

        public static RestRequest CustomRequestWithPrivateTokenHeader(string request, Method method)
        {
            RestRequest RestRequest = new RestRequest(request);
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            RestRequest.Method = method;
            return RestRequest;
        }
    }
}
