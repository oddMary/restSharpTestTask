using GitLabAPI.Builders;
using GitLabAPI.Client;
using GitLabAPI.enums;
using GitLabAPI.Factories;
using GitLabAPI.Features;
using RestSharp;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.Services
{
    public class UserRequestsService
    {
        RestClient newClient = CreateClient.getNewClient(BASE_URL);
        UserJsonBodyBuilder userStatusJsonBodyBuilder = new UserJsonBodyBuilder();

        public string GetUserState()
        {
            string requestUrl = string.Format("{0}/{{userId}}", RequestParameters.users.ToString());

            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.GET);
            request.AddUrlSegment("userId", _userId);

            IRestResponse response = newClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("state", response);
        }

        public string GetUserStatusMessage()
        {
            string requestUrl = "user/status";

            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.GET);

            IRestResponse response = newClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("message", response); ;
        }

        public string UpdateUserStatusMessage()
        {
            string requestUrl = "user/status";

            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.PUT);
            request.AddJsonBody(userStatusJsonBodyBuilder.SetMessage("SomeMessage").Build());
            IRestResponse response = newClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("message", response); ;
        }

        public string ReturnDefaultCredantialsOfUser()
        {
            string requestUrl = "user/status";

            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.PUT);
            request.AddJsonBody(userStatusJsonBodyBuilder.SetMessage("null").Build());
            IRestResponse response = newClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("message", response); ;
        }

        public string GetWarningMessageWhenAddEmailForUserThatAlreadyBeenTaken()
        {
            string requestUrl = "user/emails";
            RestRequest request = RequestFactory.CreateCustomRequestWithPrivateTokenHeader(requestUrl, Method.POST);
            request.AddJsonBody(userStatusJsonBodyBuilder.SetEmail("maryjane_1992@mail.ru").Build());
            IRestResponse response = newClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("message", response);
        }

    }
}
