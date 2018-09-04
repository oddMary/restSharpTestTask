using GitLabAPI.Tool;
using RestSharp;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.Factories
{
    public class RequestFactory
    {
        private static readonly Logger _logger = new Logger(typeof(RequestFactory));

        public static RestRequest CustomRequest(string request, Method method)
        {
            _logger.Info($"Creating {BASE_URL}{request} request");
            RestRequest RestRequest = new RestRequest(request);
            _logger.Info($"Adding header \"Private-Tokken\"");
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            _logger.Info($"Using method: {method}");
            RestRequest.Method = method;
            _logger.Info($"Request {BASE_URL}{request} created");
            return RestRequest;
        }

        public static RestRequest ProjectRequest(string request, Method method, object json)
        {
            _logger.Info($"Creating {BASE_URL}{request} request");
            RestRequest RestRequest = new RestRequest(request);
            _logger.Info($"Adding header \"Private-Tokken\"");
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            _logger.Info($"Using method: {method}");
            RestRequest.Method = method;
            _logger.Info($"Adding json body");
            RestRequest.AddJsonBody(json);
            _logger.Info($"Request {BASE_URL}{request} created");
            return RestRequest;
        }

        public static RestRequest UserRequest(string request, Method method, int userId)
        {
            _logger.Info($"Creating {BASE_URL}{request} request");
            RestRequest RestRequest = new RestRequest(request);
            _logger.Info($"Adding header \"Private-Tokken\"");
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            _logger.Info($"Using method: {method}");
            RestRequest.Method = method;
            _logger.Info($"Adding header \"userId\": {userId}");
            RestRequest.AddUrlSegment("userId", userId);
            _logger.Info($"Request {BASE_URL}{request} created");
            return RestRequest;
        }

        public static RestRequest ProjectRequest(string request, Method method, int projectId)
        {
            _logger.Info($"Creating {BASE_URL}{request} request");
            RestRequest RestRequest = new RestRequest(request);
            _logger.Info($"Adding header \"Private-Tokken\"");
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            _logger.Info($"Using method: {method}");
            RestRequest.Method = method;
            _logger.Info($"Adding header \"projectId\": {projectId}");
            RestRequest.AddUrlSegment("projectId", projectId);
            _logger.Info($"Request {BASE_URL}{request} created");
            return RestRequest;
        }

        public static RestRequest ProjectRequestWithJson(string request, Method method, int projectId, object json)
        {
            _logger.Info($"Creating {BASE_URL}{request} request");
            RestRequest RestRequest = new RestRequest(request);
            _logger.Info($"Adding header \"Private-Tokken\"");
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            _logger.Info($"Using method: {method}");
            RestRequest.Method = method;
            _logger.Info($"Adding header \"projectId\": {projectId}");
            RestRequest.AddUrlSegment("projectId", projectId);
            _logger.Info($"Adding json body");
            RestRequest.AddJsonBody(json);
            _logger.Info($"Request {BASE_URL}{request} created");
            return RestRequest;
        }

        public static RestRequest FileRequest(string request, Method method, int projectId, string fileName, object json)
        {
            _logger.Info($"Creating {BASE_URL}{request} request");
            RestRequest RestRequest = new RestRequest(request);
            _logger.Info($"Adding header \"Private-Tokken\"");
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            _logger.Info($"Using method: {method}");
            RestRequest.Method = method;
            _logger.Info($"Adding header \"projectId\": {projectId}");
            RestRequest.AddUrlSegment("projectId", projectId);
            _logger.Info($"Adding header \"fileName\": {fileName}");
            RestRequest.AddUrlSegment("fileName", fileName);
            _logger.Info($"Adding json body");
            RestRequest.AddJsonBody(json);
            _logger.Info($"Request {BASE_URL}{request} created");
            return RestRequest;
        }

        public static RestRequest BranchRequest(string request, Method method, int projectId, string newBranch)
        {
            _logger.Info($"Creating {BASE_URL}{request} request");
            RestRequest RestRequest = new RestRequest(request);
            _logger.Info($"Adding header \"Private-Tokken\"");
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            _logger.Info($"Using method: {method}");
            RestRequest.Method = method;
            _logger.Info($"Adding header \"projectId\": {projectId}");
            RestRequest.AddUrlSegment("projectId", projectId);
            _logger.Info($"Adding header \"newBranch\" {newBranch}");
            RestRequest.AddUrlSegment("newBranch", newBranch);
            _logger.Info($"Request {BASE_URL}{request} created");
            return RestRequest;
        }
    }
}
