using GitLabAPI.Builders;
using GitLabAPI.Factories;
using GitLabAPI.Features;
using GitLabAPI.Services;
using GitLabAPI.Wrapper;
using NUnit.Framework;
using RestSharp;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.Tests
{
    [TestFixture]
    public class UserTests
    {
        RestClient Client;
        UserJsonBodyBuilder UserJsonBodyBuilder => new UserJsonBodyBuilder();

        public string _state = "active";
        public string _defaultStatusMessage = "null";
        public string _message = "message";
        public string _email = "123@mail.ru";

        public string _warningMessageExistedEmail = "email:has already been taken";

        [OneTimeSetUp]
        public void SetUpServiceObject()
        {
            Client = CreateClient.GetNewClient(BASE_URL);
        }

        [Test]
        public void TestGetUserState()
        {
            RestRequest GetRequest = RequestFactory.UserRequest(_requestUrlGetUserState, Method.GET, _userId);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string state = JsonDeserializer.ReturnJsonValue("state", RestResponse); ;

            AssertService.AreEqual(state, _state);
        }

        [Test]
        public void TestGetUserStatusMessage()
        {
            object json = UserJsonBodyBuilder.SetMessage(_defaultStatusMessage).Build();

            RestRequest GetRequest = RequestFactory.RequestWithJsonBody(_requestUrlUserStatus, Method.GET, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string message = JsonDeserializer.ReturnJsonValue("message", RestResponse); ;

            AssertService.AreEqual(_defaultStatusMessage, message);
        }

        [Test]
        public void TestUpdateUserStatusMessage()
        {
            object json = UserJsonBodyBuilder.SetMessage(_message).Build();

            RestRequest GetRequest = RequestFactory.RequestWithJsonBody(_requestUrlUserStatus, Method.PUT, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string message = JsonDeserializer.ReturnJsonValue("message", RestResponse); ;

            AssertService.AreEqual(_message, message);
        }

        [Test]
        public void TestAddEmailThatAlreadyExisted()
        {
            object json = UserJsonBodyBuilder.SetId(_userId).SetEmail(_email).Build();

            RestRequest GetRequest = RequestFactory.RequestWithJsonBody(_requestUrlEmails, Method.POST, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string message = RegexMessage.RegexWarningMessage(JsonDeserializer.ReturnJsonValue("message", RestResponse));

            AssertService.AreEqual(_warningMessageExistedEmail, message);
        }

        [OneTimeTearDown]
        public void ReturnDefaultCredantialsOfUserStatus()
        {
            object json = UserJsonBodyBuilder.SetMessage(_defaultStatusMessage).Build();

            RestRequest GetRequest = RequestFactory.RequestWithJsonBody(_requestUrlUserStatus, Method.PUT, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
        }
    }
}
