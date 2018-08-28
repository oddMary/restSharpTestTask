using GitLabAPI.Client;
using GitLabAPI.enums;
using GitLabAPI.Factories;
using GitLabAPI.Features;
using GitLabAPI.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.Services
{
    public class RequestServices
    {
        RestClient newClient = CreateClient.NewClient(BASE_URL);

        public string projectId;

        public int GetNamespacesRequestStatusCode()
        {
            RestRequest request = RequestFactory.GetNameSpacesRequest();
            IRestResponse respons = newClient.Execute(request);
            return (int)respons.StatusCode;
        }    
        
        public string GetNameOfNewProject()
        {
            RestRequest request = RequestFactory.AddProjectRequest();
            request.AddJsonBody(
                new
                {
                    description = "NewProject",
                    name = "SomeProject"
                });            
            IRestResponse response = newClient.Execute(request);
            projectId = CustomJsonDeserializer.ReturnJsonValue("id", response);
            return CustomJsonDeserializer.ReturnJsonValue("name", response);
        }

        public string GetNameOfUpdatedCreatedProject()
        {
            string requestUrl = string.Format("{0}/{{projectId}}", RequestParameters.projects.ToString());
            RestRequest request = RequestFactory.CreateGeneralRequest(requestUrl, PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN, Method.PUT);
            request.AddUrlSegment("projectId", projectId);
            request.AddJsonBody(
                new
                {
                    description = "UpdatedProject",
                    name = "UpdatedProject"
                });
            IRestResponse response = newClient.Execute(request);
            return CustomJsonDeserializer.ReturnJsonValue("name", response);
        }

        public int GetDeleteUpdatedProjectStatusCode()
        {
            string requestUrl = string.Format("{0}/{{projectId}}", RequestParameters.projects.ToString());
            RestRequest request = RequestFactory.CreateGeneralRequest(requestUrl, PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN, Method.DELETE);
            request.AddUrlSegment("projectId", projectId);
            IRestResponse response = newClient.Execute(request);
            return (int)response.StatusCode;
        }
    }
}
