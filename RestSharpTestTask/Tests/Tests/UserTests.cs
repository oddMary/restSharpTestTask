using GitLabAPI.Services;
using NUnit.Framework;
using RestSharp;
using System.Text.RegularExpressions;

namespace GitLabAPI.Tests
{
    [TestFixture]
    class UserTests
    {
        UserRequestsService UserRequestsService;

        public string _stete = "active";
        public string _defaultStatusMessage = "null";
        public string _message = "message";
        public string _email = "123@mail.ru";

        public static string _warningMessageEmail = "{\"email\":[\"has already been taken\"]}";

        [OneTimeSetUp]
        public void SetUpServiceObject()
        {
            UserRequestsService = new UserRequestsService();
        }

        [Test, Order(1)]
        public void TestGetUserState()
        {
            Assert.AreEqual(UserRequestsService.GetUserState(
                GlobalParameters._requestUrlGetUserState, Method.GET, GlobalParameters._userId), _stete);
        }

        [Test, Order(2)]
        public void TestGetUserStatusMessage()
        {
            Assert.AreEqual(UserRequestsService.GetUserStatusMessage(
                GlobalParameters._requestUrlUserStatus, Method.GET, GlobalParameters._userId), _defaultStatusMessage);
        }

        [Test, Order(3)]
        public void TestUpdateUserStatusMessage()
        {
            Assert.AreEqual(UserRequestsService.GetUpdatedUserStatusMessage(
                GlobalParameters._requestUrlUserStatus, Method.PUT, _message), _message);
        }

        [Test, Order(4)]
        public void TestAddEmailThatAlreadyExisted()
        {
            string username = Regex.Replace(_warningMessageEmail, "\\([^\\(]*\\)", "");

            Assert.AreEqual(UserRequestsService.GetMessageEmailAlreadyExist(
                GlobalParameters._requestUrlEmails, Method.POST, GlobalParameters._userId, _email), username);
        }

        [OneTimeTearDown]
        public void ReturnDefaultCredantialsOfUserStatus()
        {
            UserRequestsService.ReturnDefaultCredantialsOfUserStatus(
                GlobalParameters._requestUrlUserStatus, Method.PUT, _defaultStatusMessage);
        }
    }
}
