using GitLabAPI.Client;
using GitLabAPI.Factories;
using GitLabAPI.Features;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GitLabAPI.GlobalParameters; 

namespace GitLabAPI.Services
{
    public class BranchRequestsService
    {
        ProjectRequestsService projectRequestsService = new ProjectRequestsService();
        RestClient newClient = CreateClient.getNewClient(BASE_URL);

        public string newBranchName = "NewBranchName";
        public string Branch = "master";

        public string GetNameOfNewBrunchCreated()
        {
            string requestUrl = "projects/{ProjectId}/repository/branches?branch={NewBranchName}&ref={Branch}";
            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.POST);
            request.AddUrlSegment("ProjectId", 7982135);
            request.AddUrlSegment("NewBranchName", newBranchName);
            request.AddUrlSegment("Branch", Branch);

            IRestResponse response = newClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("name", response);
        }

        public int GetStatusCodeOfDeletingCreatedBrunch()
        {
            string requestUrl = "projects/{ProjectId}/repository/branches/{NewBranchName}";
            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.DELETE);
            request.AddUrlSegment("ProjectId", 7982135);
            request.AddUrlSegment("NewBranchName", newBranchName);

            IRestResponse response = newClient.Execute(request);

            return (int)response.StatusCode;
        }
    }
}
