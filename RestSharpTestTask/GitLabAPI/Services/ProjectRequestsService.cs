using System;
using GitLabAPI.Builders;
using GitLabAPI.Client;
using GitLabAPI.enums;
using GitLabAPI.Factories;
using GitLabAPI.Features;
using RestSharp;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.Services
{
    public class ProjectRequestsService
    {
        RestClient newClient = CreateClient.getNewClient(BASE_URL);
        ProjectJsonBodyBuilder ProjectBodyJson = new ProjectJsonBodyBuilder();
        WikiJsonBodyBuilder WikiJsonBody = new WikiJsonBodyBuilder();

        public string projectId;

        public int GetNamespacesRequestStatusCode()
        {
            RestRequest request = RequestFactory.GetNameSpacesRequestWithPrivateTokenHeader();

            IRestResponse respons = newClient.Execute(request);

            return (int)respons.StatusCode;
        }

        public string GetNameOfNewProject()
        {
            RestRequest request = RequestFactory.AddProjectRequestWithPrivateTokenHeader();
            request.AddJsonBody(ProjectBodyJson.SetDescription("NewProject").SetName("SomeProject").Build());

            IRestResponse response = newClient.Execute(request);
            // setUp projectId
            projectId = CustomJsonDeserializer.ReturnJsonValue("id", response);

            return CustomJsonDeserializer.ReturnJsonValue("name", response);
        }

        public string GetNameOfUpdatedProject()
        {
            string requestUrl = string.Format("{0}/{{projectId}}", RequestParameters.projects.ToString());

            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.PUT);
            request.AddUrlSegment("projectId", projectId);
            request.AddJsonBody(ProjectBodyJson.SetDescription("UpdatedProject").SetName("UpdatedProject").Build());

            IRestResponse response = newClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("name", response);
        }

        public int GetStatusCodeAfterArchivedProject()
        {
            string requestUrl = "projects/{ProjectId}/archive";

            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.POST);
            request.AddUrlSegment("ProjectId", 7982135);

            IRestResponse response = newClient.Execute(request);

            return (int)response.StatusCode;
        }

        public int GetStatusCodeUnarchivedProject()
        {
            string requestUrl = "projects/{ProjectId}/unarchive";

            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.POST);
            request.AddUrlSegment("ProjectId", 7982135);
            IRestResponse response = newClient.Execute(request);

            return (int)response.StatusCode;
        }

        public string GetTitleCreateWikiPage()
        {
            string requestUrl = "projects/{ProjectId}/wikis";

            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.POST);
            request.AddUrlSegment("ProjectId", 7982135);
            request.AddJsonBody(WikiJsonBody.SetContent("SomeContent").SetTitle("SomeTitle").Build());

            IRestResponse response = newClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("title", response);
        }

        public int GetStatusCodeDeleteWikiPageSuccessful()
        {
            string requestUrl = "projects/{ProjectId}/wikis/{slug}";

            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.DELETE);
            request.AddUrlSegment("ProjectId", 7982135);
            request.AddUrlSegment("slug", "SomeTitle");

            IRestResponse response = newClient.Execute(request);

            return (int)response.StatusCode;
        }

        public int GetDeleteProjectActionStatusCode()
        {
            string requestUrl = string.Format("{0}/{{projectId}}", RequestParameters.projects.ToString());

            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.DELETE);
            request.AddUrlSegment("projectId", projectId);

            IRestResponse response = newClient.Execute(request);

            return (int)response.StatusCode;
        }
    }
}
