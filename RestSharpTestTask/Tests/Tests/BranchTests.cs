using NUnit.Framework;
using GitLabAPI.Services;
using GitLabAPI.enums;
using GitLabAPI;
using RestSharp;

namespace Tests.Tests
{
    [TestFixture]
    class BranchTests
    {
        BranchRequestsService BranchRequestsService;

        public string _newBranch = "newBranch";
        public string _branch = "master";

        [OneTimeSetUp]
        public void SetUpServiceObject()
        {
            BranchRequestsService = new BranchRequestsService();
        }

        [Test, Order(1)]
        public void TestCreateNewBranch()
        {
            Assert.AreEqual(BranchRequestsService.GetNameCreatedBranch(
                GlobalParameters._requestUrlCreateBranch, Method.POST, GlobalParameters._projectId, _newBranch, _branch), _newBranch);
        }

        [Test, Order(2)]
        public void TestDeleteBranch()
        {
            Assert.AreEqual(BranchRequestsService.GetStatusCodeDeleteBrunch(
                GlobalParameters._requestUrlDeleteBranch, Method.DELETE, GlobalParameters._projectId, _newBranch), (int)StatusCode.DELETE);
        }
    }
}
