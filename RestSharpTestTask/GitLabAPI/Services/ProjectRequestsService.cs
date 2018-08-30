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
        RestClient RestClient = CreateClient.GetNewClient(BASE_URL);
        ProjectJsonBodyBuilder ProjectBodyJson => new ProjectJsonBodyBuilder();
        WikiJsonBodyBuilder WikiJsonBody => new WikiJsonBodyBuilder();        

        public int GetNamespacesStatusCode()
        {
            RestRequest request = RequestFactory.GetNameSpacesRequestWithPrivateTokenHeader();
            IRestResponse respons = RestClient.Execute(request);
            return (int)respons.StatusCode;
        }

        public string GetNameOfNewProject(string description, string projectName)
        {
            RestRequest request = RequestFactory.PostProjectRequestWithPrivateTokenHeader();
            request.AddJsonBody(ProjectBodyJson.SetDescription(description).SetName(projectName).Build());

            IRestResponse response = RestClient.Execute(request);
            // setUp projectId
            _createdProjectId = CustomJsonDeserializer.ReturnJsonValue("id", response);

            return CustomJsonDeserializer.ReturnJsonValue("name", response);
        }

        public string GetNameOfUpdatedProject(string requestUrl, Method method, string description, string newProjectName)
        {
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddUrlSegment("projectId", _createdProjectId);
            request.AddJsonBody(ProjectBodyJson.SetDescription(description).SetName(newProjectName).Build());

            IRestResponse response = RestClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("name", response);
        }

        public int GetStatusCodeArchiveProject(string requestUrl, Method method)
        {           
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddUrlSegment("projectId", _createdProjectId);

            IRestResponse response = RestClient.Execute(request);

            return (int)response.StatusCode;
        }

        public int GetStatusCodeUnarchiveProject(string requestUrl, Method method)
        {
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddUrlSegment("projectId", _createdProjectId);

            IRestResponse response = RestClient.Execute(request);

            return (int)response.StatusCode;
        }

        public string GetTitleCreatedWikiPage(string requestUrl, Method method, string content, string title)
        {
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddUrlSegment("projectId", _createdProjectId);
            request.AddJsonBody(WikiJsonBody.SetContent(content).SetTitle(title).Build());

            IRestResponse response = RestClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("title", response);
        }

        public int GetStatusCodeDeleteWikiPage(string requestUrl, Method method, string content, string title)
        { 
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddUrlSegment("projectId", _createdProjectId);
            request.AddUrlSegment("slug", title);

            IRestResponse response = RestClient.Execute(request);

            return (int)response.StatusCode;
        }

        public int GetStatusCodeDeleteProject(string requestUrl, Method method)
        {
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddUrlSegment("projectId", _createdProjectId);

            IRestResponse response = RestClient.Execute(request);

            return (int)response.StatusCode;
        }
    }
}
