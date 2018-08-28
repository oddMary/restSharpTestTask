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

        public static RestRequest GetNameSpacesRequest()
        {
            RestRequest RestRequest = new RestRequest(RequestParameters.namespaces.ToString());
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            RestRequest.Method = Method.GET;
            return RestRequest;
        }

        public static RestRequest AddProjectRequest()
        {
            RestRequest RestRequest = new RestRequest(RequestParameters.projects.ToString());
            RestRequest.AddHeader(PRIVATE_TOKEN_HEADER_NAME, PRIVATE_TOKEN);
            RestRequest.Method = Method.POST;
            return RestRequest;
        }


        public static RestRequest CreateGeneralRequest(string request, string headerName, string headerValue, Method method)
        {
            RestRequest RestRequest = new RestRequest(request);
            RestRequest.AddHeader(headerName, headerValue);
            RestRequest.Method = method;
            return RestRequest;
        }


    }
}
