using GitLabAPI.Builders;
using GitLabAPI.Factories;
using GitLabAPI.Features;
using GitLabAPI.Services;
using GitLabAPI.Wrapper;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;
using static GitLabAPI.GlobalParameters;

namespace Tests.Tests
{
    [TestFixture]
    [AllureNUnit]
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
            Client = ClientFactory.GetInstance();
        }

        [Test]
        public void TestGetUserState()
        {
            RestRequest GetRequest = RequestFactory.UserRequest(_requestUrlGetUserState, Method.GET, _userId);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string state = JsonDeserializer.ReturnJsonValue("state", RestResponse); ;

            AssertService.AssertEqual(state, _state);
        }

        [Test]
        public void TestGetUserStatusMessage()
        {
            object json = UserJsonBodyBuilder.SetMessage(_defaultStatusMessage).Build();

            RestRequest GetRequest = RequestFactory.ProjectRequest(_requestUrlUserStatus, Method.GET, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string message = JsonDeserializer.ReturnJsonValue("message", RestResponse); ;

            AssertService.AssertEqual(_defaultStatusMessage, message);
        }

        [Test]
        public void TestUpdateUserStatusMessage()
        {
            object json = UserJsonBodyBuilder.SetMessage(_message).Build();

            RestRequest GetRequest = RequestFactory.ProjectRequest(_requestUrlUserStatus, Method.PUT, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string message = JsonDeserializer.ReturnJsonValue("message", RestResponse); ;

            AssertService.AssertEqual(_message, message);
        }

        [Test]
        public void TestAddEmailThatAlreadyExisted()
        {
            object json = UserJsonBodyBuilder.SetId(_userId).SetEmail(_email).Build();

            RestRequest GetRequest = RequestFactory.ProjectRequest(_requestUrlEmails, Method.POST, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string message = RegexMessage.RegexWarningMessage(JsonDeserializer.ReturnJsonValue("message", RestResponse));

            AssertService.AssertEqual(_warningMessageExistedEmail, message);
        }

        [OneTimeTearDown]
        public void ReturnDefaultCredantialsOfUserStatus()
        {
            object json = UserJsonBodyBuilder.SetMessage(_defaultStatusMessage).Build();

            RestRequest GetRequest = RequestFactory.ProjectRequest(_requestUrlUserStatus, Method.PUT, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
        }
    }
}
