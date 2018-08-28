using GitLabAPI.enums;
using GitLabAPI.Services;
using NUnit.Framework;

namespace GitLabAPI
{
    [TestFixture]
    class Test
    {
        RequestServices requestService = new RequestServices();

        [Test, Order(1)]
        public void TestGetHNameSpaces()
        {
            Assert.AreEqual(requestService.GetNamespacesRequestStatusCode(), (int)StatusCode.OK);
        }

        [Test, Order(2)]
        public void TestAddProject()
        {
            Assert.AreEqual(requestService.GetNameOfNewProject(), "SomeProject");
        }

        [Test, Order(3)]
        public void TestUpdateProject()
        {
            Assert.AreEqual(requestService.GetNameOfUpdatedCreatedProject(), "UpdatedProject");
        }

        [Test, Order(4)]
        public void TestDeleteUpdatedProject()
        {
            Assert.AreEqual(requestService.GetDeleteUpdatedProjectStatusCode(), (int)StatusCode.DELETED);
        }
    }
}
