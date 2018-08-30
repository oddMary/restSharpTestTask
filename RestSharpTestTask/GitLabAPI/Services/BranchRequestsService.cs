using GitLabAPI.Client;
using GitLabAPI.Factories;
using GitLabAPI.Features;
using RestSharp;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.Services
{
    public class BranchRequestsService
    {
        ProjectRequestsService ProjectRequestsService => new ProjectRequestsService();
        RestClient RestClient = CreateClient.GetNewClient(BASE_URL);

        public string GetNameCreatedBranch(string requestUrl, Method method, int projectId, string newBranch, string branch)
        {
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("newBranch", newBranch);
            request.AddUrlSegment("branch", branch);

            IRestResponse response = RestClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("name", response);
        }

        public int GetStatusCodeDeleteBrunch(string requestUrl, Method method, int projectId, string newBranch)
        {
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("newBranch", newBranch);

            IRestResponse response = RestClient.Execute(request);

            return (int)response.StatusCode;
        }
    }
}
