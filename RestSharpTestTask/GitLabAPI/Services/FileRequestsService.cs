using GitLabAPI.Builders;
using GitLabAPI.Client;
using GitLabAPI.Factories;
using GitLabAPI.Features;
using RestSharp;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.Services
{
    public class FileRequestsService
    {
        RestClient newClient = CreateClient.getNewClient(BASE_URL);
        FileJsonBodyBuilder FileJsonBody = new FileJsonBodyBuilder();
        ProjectRequestsService ProjectRequestsService = new ProjectRequestsService();

        public int GetErrorMessageWhenCreateFileWithoutTheCommitMessage()
        {
            string requestUrl = "projects/{ProjectId}/repository/files/{FileName}";
            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.POST);
            request.AddUrlSegment("ProjectId", 7982135);
            request.AddUrlSegment("FileName", "file");
            request.AddJsonBody(FileJsonBody.SetFilePath("file").SetBranch("master").Build());
            IRestResponse response = newClient.Execute(request);
                
            return (int)response.StatusCode;
        }

        public string GetErrorMessageCreateFileInNotChosenRepository()
        {
            string requestUrl = "projects/{ProjectId}/repository/files/{FileName}";
            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.POST);
            request.AddUrlSegment("ProjectId", 7982135);
            request.AddUrlSegment("FileName", "file");
            request.AddJsonBody(FileJsonBody.SetFilePath("file").SetCommitMessage("commt").Build());
            IRestResponse response = newClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("message", response);
        }

        public int CreateFileInRepository()
        {
            string requestUrl = "projects/{ProjectId}/repository/files/{FileName}";
            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.POST);
            request.AddUrlSegment("ProjectId", 7982135);
            request.AddUrlSegment("FileName", "file");
            request.AddJsonBody(FileJsonBody.SetFilePath("file").SetBranch("master").SetCommitMessage("commt").Build());
            IRestResponse response = newClient.Execute(request);

            return (int)response.StatusCode;
        }

        public string GetErrorMessageAfterTryingToCreateFileWithAlreadyExistedName()
        {
            string requestUrl = "projects/{ProjectId}/repository/files/{FileName}";
            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.POST);
            request.AddUrlSegment("ProjectId", 7982135);
            request.AddUrlSegment("FileName", "file");
            request.AddJsonBody(FileJsonBody.SetFilePath("file").SetBranch("master").SetCommitMessage("commt").Build());
            IRestResponse response = newClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("message", response);
        }

        public int GetStatusCodeDeleteFileFromArchivedRepositoryFail()
        {
            if(ProjectRequestsService.GetStatusCodeAfterArchivedProject() == 201)
            {
                string requestUrl = "projects/{ProjectId}/repository/files/{FileName}";
                RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.DELETE);
                request.AddUrlSegment("ProjectId", 7982135);
                request.AddUrlSegment("FileName", "file");
                request.AddJsonBody(FileJsonBody.SetBranch("master").SetCommitMessage("commit").Build());
                IRestResponse response = newClient.Execute(request);

                return (int)response.StatusCode;
            }

            return 500;
        }

        public int GetStausCodeDeleteFileFromRepository()
        {
            string requestUrl = "projects/{ProjectId}/repository/files/{FileName}";
            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.DELETE);
            request.AddUrlSegment("ProjectId", 7982135);
            request.AddUrlSegment("FileName", "file");
            request.AddJsonBody(FileJsonBody.SetBranch("master").SetCommitMessage("commit").Build());
            IRestResponse response = newClient.Execute(request);

            return (int)response.StatusCode;
        }
    }
}

