using GitLabAPI.Services;
using NUnit.Framework;

namespace GitLabAPI.Tests
{
    [TestFixture]
    class UserTests
    {
        UserRequestsService UserRequestsService;

        //[OneTimeSetUp]
        //public void SetUpServiceObject()
        //{
        //    UserRequestsService = new UserRequestsService();
        //}        

        //[Test, Order (1)]
        //public void TestGetUserState()
        //{
        //    Assert.AreEqual(UserRequestsService.GetUserState(), "active");
        //}

        //[Test, Order(2)]
        //public void TestUserStatusMessge()
        //{
        //    Assert.AreEqual(UserRequestsService.GetUserStatusMessage(), "null");
        //}

        //[Test, Order(3)]
        //public void TestUpdateUserStatusMessage()
        //{
        //    Assert.AreEqual(UserRequestsService.UpdateUserStatusMessage(), "SomeMessage");            
        //}

        //[Test]
        //public void TestGetMessage()
        //{
        //    Assert.AreEqual(UserRequestsService.GetWarningMessageWhenAddEmailForUserThatAlreadyBeenTaken(), "{\"email\":[\"has already been taken\"]}");
        //}

        //[OneTimeTearDown]
        //public void ReturnDefaultCredantialsOfUser()
        //{
        //    UserRequestsService.ReturnDefaultCredantialsOfUser();
        //}
    }
}
