using RestSharp;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.Factories
{
    public class RequestFactory
    {
        public static RestRequest CustomRequest(string request, Method method)
        {
            RestRequest RestRequest = new RestRequest(request);
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            RestRequest.Method = method;
            return RestRequest;
        }

        public static RestRequest RequestWithJsonBody(string request, Method method, object json)
        {
            RestRequest RestRequest = new RestRequest(request);
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            RestRequest.Method = method;
            RestRequest.AddJsonBody(json);
            return RestRequest;
        }

        public static RestRequest UserRequest(string request, Method method, int userId)
        {
            RestRequest RestRequest = new RestRequest(request);
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            RestRequest.Method = method;
            RestRequest.AddUrlSegment("userId", userId);
            return RestRequest;
        }

        public static RestRequest ProjectRequest(string request, Method method, int projectId)
        {
            RestRequest RestRequest = new RestRequest(request);
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            RestRequest.Method = method;
            RestRequest.AddUrlSegment("projectId", projectId);
            return RestRequest;
        }

        public static RestRequest ProjectRequestWithJson(string request, Method method, int projectId, object json)
        {
            RestRequest RestRequest = new RestRequest(request);
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            RestRequest.Method = method;
            RestRequest.AddUrlSegment("projectId", projectId);
            RestRequest.AddJsonBody(json);
            return RestRequest;
        }

        public static RestRequest FileRequest(string request, Method method, int projectId, string fileName, object json)
        {
            RestRequest RestRequest = new RestRequest(request);
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            RestRequest.Method = method;
            RestRequest.AddUrlSegment("projectId", projectId);
            RestRequest.AddUrlSegment("fileName", fileName);
            RestRequest.AddJsonBody(json);
            return RestRequest;
        }

        public static RestRequest BranchRequest(string requestUrl, Method method, int projectId, string newBranch)
        {
            RestRequest RestRequest = new RestRequest(requestUrl);
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            RestRequest.Method = method;
            RestRequest.AddUrlSegment("projectId", projectId);
            RestRequest.AddUrlSegment("newBranch", newBranch);
            return RestRequest;
        }
    }
}
