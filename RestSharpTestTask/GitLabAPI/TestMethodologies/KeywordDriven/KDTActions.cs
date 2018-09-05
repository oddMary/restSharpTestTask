using GitLabAPI.enums;
using GitLabAPI.Factories;
using GitLabAPI.Services;
using GitLabAPI.Tool;
using RestSharp;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.KDTData
{
    public static class KeywordDrivenTesting
    {
        static RestRequest _restRequest;
        static string _statusCode;
        private static readonly Logger _logger = new Logger(typeof(KeywordDrivenTesting));

        public static void PerformAction(string keyword, RestClient client, string value, StatusCode statusCode, string branchName)
        {
            switch (keyword)
            {
                case ("request"):
                    GetRequestFactory(value, branchName);
                    break;
                case ("addSegment"):
                    _logger.Info($"Adding header \"branch\": {value}");
                    _restRequest.AddUrlSegment("branch", value);
                    break;
                case "response":
                    IRestResponse response = client.Execute(_restRequest);
                    _logger.Info($"Response {response.ResponseUri} received");
                    _statusCode = response.StatusCode.ToString();
                    break;
                case "assert":
                    AssertService.AssertEqual(statusCode.ToString(), _statusCode);
                    break;
            }
        }

        public static RestRequest GetRequestFactory(string requestType, string branchName)
        {
            switch (requestType)
            {
                case "AddBranch":
                    return _restRequest = RequestFactory.BranchRequest(_requestUrlBranch, Method.POST, _projectId, branchName);
                case "DeleteBranch":
                    return _restRequest = RequestFactory.BranchRequest(_requestUrlDeleteBranch, Method.DELETE, _projectId, branchName);
            }
            return null;
        }
    }
}
