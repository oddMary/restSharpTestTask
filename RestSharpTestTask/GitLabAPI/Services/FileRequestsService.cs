using GitLabAPI.Client;
using GitLabAPI.Factories;
using GitLabAPI.Features;
using GitLabAPI.JsonBodies;
using GitLabAPI.enums;
using RestSharp;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.Services
{
    public class FileRequestsService
    {
        RestClient RestClient => CreateClient.GetNewClient(BASE_URL);
        ProjectRequestsService ProjectRequestsService => new ProjectRequestsService();        

        public string GetErrorMessageCreateFileWithoutTheCommitMessage(
            string requestUrl, Method method, int projectId, string fileName, string branch)
        {
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("fileName", fileName);
            request.AddJsonBody(new FileJsonBody(fileName, branch));

            IRestResponse response = RestClient.Execute(request);
                
            return CustomJsonDeserializer.ReturnJsonValue("error", response);
        }

        public string GetErrorMessageCreateFileInNotChosenBranch(
            string requestUrl, Method method, int projectId, string fileName, string commitMessage)
        {
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("fileName", fileName);
            request.AddJsonBody(new FileJsonBodyChield(fileName, commitMessage));

            IRestResponse response = RestClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("message", response);
        }

        public int GetStatusCodeCreateFileInRepository(
            string requestUrl, Method method, int projectId, string fileName, string branch, string content, string commitMessage)
        {
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("fileName", fileName);
            request.AddJsonBody(new FileJsonBodyChield(fileName, branch, content, commitMessage));

            IRestResponse response = RestClient.Execute(request);

            return (int)response.StatusCode;
        }

        public string GetErrorMessageCreateFileWithAlreadyExistedName(
            string requestUrl, Method method, int projectId, string fileName, string branch, string content, string commitMessage)
        {
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("fileName", fileName);
            request.AddJsonBody(new FileJsonBodyChield(fileName, branch, content, commitMessage));

            IRestResponse response = RestClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("message", response);
        }

        public int GetStatusCodeDeleteFileFromArchivedRepository(
            string requestUrl, Method method, int projectId, string fileName, string commitMessage)
        {
            if(ProjectRequestsService.GetStatusCodeArchiveProject(_requestUrlArchived, Method.POST) == (int)StatusCode.CREATED)
            {
                RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
                request.AddUrlSegment("projectId", _createdProjectId);
                request.AddUrlSegment("fileName", fileName);
                request.AddJsonBody(new FileJsonBodyChield(fileName, commitMessage));

                IRestResponse response = RestClient.Execute(request);

                return (int)response.StatusCode;
            }
            return (int)StatusCode.INTERNAL_ERROR;
        }

        public int GetStatusCodeDeleteFileFromRepository(
            string requestUrl, Method method, int projectId, string fileName, string branch, string content, string commitMessage)
        {
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("fileName", fileName);
            request.AddJsonBody(new FileJsonBodyChield(fileName, branch, content, commitMessage));

            IRestResponse response = RestClient.Execute(request);

            return (int)response.StatusCode;
        }
    }
}

