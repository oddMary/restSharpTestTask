using GitLabAPI.enums;
using GitLabAPI.Factories;
using GitLabAPI.Services;
using RestSharp;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.KDTData
{
    public static class KeywordDrivenTesting
    {
        static RestRequest _restRequest;
        static string _statusCode;        

        public static void PerformAction(string keyword, RestClient client, string value, StatusCode statusCode, string branchName)
        {
            switch (keyword)
            {
                case ("request"):
                    GetRequestFactory(value, branchName);
                    break;
                case ("addSegment"):
                    _restRequest.AddUrlSegment("branch", value);
                    break;
                case "response":
                    _statusCode = client.Execute(_restRequest).StatusCode.ToString();
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
