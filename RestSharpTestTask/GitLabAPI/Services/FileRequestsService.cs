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

        public string GetErrorMessageWhenCreateFileWithoutTheCommitMessage()
        {
            string requestUrl = "projects/{ProjectId}/repository/files/{FileName}";
            //string requestUrl = "projects/7982135/repository/files/file";
            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.POST);
            request.AddUrlSegment("ProjectId", 7982135);
            request.AddUrlSegment("FileName", "file");

            IRestResponse response = newClient.Execute(request);
                
            return CustomJsonDeserializer.ReturnJsonValue("error", response);
        }

        public void GetErrorMessageCreateFileInNotChosenRepository() { }

        public void CreateFileInRepository() { }

        public void GetErrorMessageAfterTryingToCreateFileWithAlreadyExistedName() { }

        public void GetErrorMEssageDeleteFileFromArchivedRepository() { }

        public void GetStausCodeDeleteFileFromRepository() { }
    }
}

