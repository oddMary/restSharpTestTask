using GitLabAPI.enums;
using GitLabAPI.Services;
using NUnit.Framework;

namespace GitLabAPI
{
    [TestFixture]
    class ProjectTests
    {
        ProjectRequestsService RequestService;

        //[OneTimeSetUp]
        //public void SetUpServiceObject()
        //{
        //    RequestService = new ProjectRequestsService();
        //}

        //[Test, Order(1)]
        //public void TestGetNameSpaces()
        //{
        //    Assert.AreEqual(RequestService.GetNamespacesRequestStatusCode(), (int)StatusCode.OK);
        //}

        //[Test, Order(2)]
        //public void TestAddProject()
        //{
        //    Assert.AreEqual(RequestService.GetNameOfNewProject(), "SomeProject");
        //}

        //[Test, Order(3)]
        //public void TestUpdateProject()
        //{
        //    Assert.AreEqual(RequestService.GetNameOfUpdatedProject(), "UpdatedProject");
        //}

        //[Test, Order(4)]
        //public void TestDeleteUpdatedProject()
        //{
        //    Assert.AreEqual(RequestService.GetDeleteProjectActionStatusCode(), (int)StatusCode.DELETED);
        //}
    }
}
