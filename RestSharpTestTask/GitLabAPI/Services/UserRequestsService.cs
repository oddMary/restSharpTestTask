using GitLabAPI.Builders;
using GitLabAPI.Client;
using GitLabAPI.enums;
using GitLabAPI.Factories;
using GitLabAPI.Features;
using GitLabAPI.Wrapper;
using RestSharp;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.Services
{
    public class UserRequestsService
    {
        RestClient RestClient => CreateClient.GetNewClient(BASE_URL);
        UserJsonBodyBuilder UserStatusJsonBodyBuilder => new UserJsonBodyBuilder();
          
        public string GetUserState(string requestUrl, Method method, int userId)
        {
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddUrlSegment("userId", userId);

            IRestResponse response = RestClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("state", response);
        }

        public string GetUserStatusMessage(string requestUrl, Method method, int userId)
        {
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddUrlSegment("userId", userId);
            IRestResponse response = RestClient.Execute(request);
            return CustomJsonDeserializer.ReturnJsonValue("message", response); ;
        }

        public string GetUpdatedUserStatusMessage(string requestUrl, Method method, string message)
        {
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddJsonBody(UserStatusJsonBodyBuilder.SetMessage(message).Build());

            IRestResponse response = RestClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("message", response); ;
        }
        
        public string ReturnDefaultCredantialsOfUserStatus(string requestUrl, Method method, string defaultMessageNull)
        {
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddJsonBody(UserStatusJsonBodyBuilder.SetMessage(defaultMessageNull).Build());

            IRestResponse response = RestClient.Execute(request);

            return CustomJsonDeserializer.ReturnJsonValue("message", response); ;
        }

        public string GetMessageEmailAlreadyExist(string requestUrl, Method method, int userId, string email)
        {            
            RestRequest request = RequestFactory.CustomRequestWithPrivateTokenHeader(requestUrl, method);
            request.AddJsonBody(UserStatusJsonBodyBuilder.SetId(userId).SetEmail(email).Build());

            IRestResponse response = RestClient.Execute(request);

            return RegexMessage.RegexWarningMessage(CustomJsonDeserializer.ReturnJsonValue("message", response));
        }

    }
}
