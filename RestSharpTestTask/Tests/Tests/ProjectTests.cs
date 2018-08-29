using GitLabAPI.enums;
using GitLabAPI.Services;
using NUnit.Framework;

namespace GitLabAPI
{
    [TestFixture]
    class ProjectTests
    {
        ProjectRequestsService ProjectRequestService;

        [OneTimeSetUp]
        public void SetUpServiceObject()
        {
            ProjectRequestService = new ProjectRequestsService();
        }

        //[Test, Order(1)]
        //public void TestGetNameSpaces()
        //{
        //    Assert.AreEqual(ProjectRequestService.GetNamespacesRequestStatusCode(), (int)StatusCode.OK);
        //}

        //[Test, Order(2)]
        //public void TestAddProject()
        //{
        //    Assert.AreEqual(ProjectRequestService.GetNameOfNewProject(), "SomeProject");
        //}

        //[Test, Order(3)]
        //public void TestUpdateProject()
        //{
        //    Assert.AreEqual(ProjectRequestService.GetNameOfUpdatedProject(), "UpdatedProject");
        //}

        //[Test, Order(4)]
        //public void TestArchiveProjectSuccesful()
        //{
        //    Assert.AreEqual(ProjectRequestService.GetStatusCodeAfterArchivedProject(), 201);
        //}

        //[Test, Order(5)]
        //public void TestUnarchiveProjectSuccesful()
        //{
        //    Assert.AreEqual(ProjectRequestService.GetStatusCodeUnarchivedProject(), 201);
        //}

        //[Test, Order(6)]
        //public void TestCreatedWikiPage()
        //{
        //    Assert.AreEqual(ProjectRequestService.GetTitleCreateWikiPage(), "SomeTitle");
        //}

        //[Test, Order(7)]
        //public void TestDeleteWikiPAgeSuccessful()
        //{
        //    Assert.AreEqual(ProjectRequestService.GetStatusCodeDeleteWikiPageSuccessful(), 204);
        //}

        //[Test, Order(6)]
        //public void TestDeleteUpdatedProject()
        //{
        //    Assert.AreEqual(ProjectRequestService.GetDeleteProjectActionStatusCode(), (int)StatusCode.DELETED);
        //}
    }
}
