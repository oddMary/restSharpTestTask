using GitLabAPI.enums;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.Factories
{
    public class RequestFactory
    {
        public int projectId = 10;

        public static RestRequest GetNameSpacesRequestWithPrivateTokenHeader()
        {
            RestRequest RestRequest = new RestRequest(RequestParameters.namespaces.ToString());
            RestRequest.AddHeader("Private-Token", PRIVATE_TOKEN);
            RestRequest.Method = Method.GET;
            return RestRequest;
        }

        public static RestRequest AddProjectRequestWithPrivateTokenHeader()
        {
            RestRequest RestRequest = new RestRequest(RequestParameters.projects.ToString());
            RestRequest.AddHeader("Private-Token", PRIVATE_TOKEN);
            RestRequest.Method = Method.POST;
            return RestRequest;
        }

        public static RestRequest CreateCustomRequestWithPrivateTokenHeader(string request, Method method)
        {
            RestRequest RestRequest = new RestRequest(request);
            RestRequest.AddHeader("Private-Token", PRIVATE_TOKEN);
            RestRequest.Method = method;
            return RestRequest;
        }
    }
}
