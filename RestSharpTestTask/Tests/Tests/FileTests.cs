using GitLabAPI.Services;
using NUnit.Framework;

namespace Tests.Tests
{
    [TestFixture]
    class FileTests
    {
        FileRequestsService FileRequestsService;

        [OneTimeSetUp]
        public void SetUpServiceObject()
        {
            FileRequestsService = new FileRequestsService();
        }

        [Test, Order(1)]
        public void GetErrorMessage()
        {
            Assert.AreEqual(FileRequestsService.GetErrorMessageWhenCreateFileWithoutTheCommitMessage(), "NewBranchName");
        }
    }
}
