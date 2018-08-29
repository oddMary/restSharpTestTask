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

        //[Test, Order(1)]
        //public void GetStatusCodeFailUploadFileWithoutCommitMessage()
        //{
        //    Assert.AreEqual(FileRequestsService.GetErrorMessageWhenCreateFileWithoutTheCommitMessage(), 500);
        //}

        //[Test, Order(2)]
        //public void GetErrorMessageTryToUploadFileWithoutChoosingBranch()
        //{
        //    Assert.AreEqual(FileRequestsService.GetErrorMessageCreateFileInNotChosenRepository(), "You can only create or edit files when you are on a branch");
        //}

        //[Test, Order(3)]
        //public void GetStatusCodeUploadFileSuccessful()
        //{
        //    Assert.AreEqual(FileRequestsService.CreateFileInRepository(), 201);
        //}

        //[Test, Order(4)]
        //public void GetErrorMessageAfterTryingToCreateFileWithAlreadyExistedName()
        //{
        //    Assert.AreEqual(FileRequestsService.GetErrorMessageAfterTryingToCreateFileWithAlreadyExistedName(), "A file with this name already exists");
        //}

        //РАЗАРХИВИРОВАТЬ ПОСЛЕ ОКОНЧАНИЯ ТЕСТА !!!!!!!!!!111!11111!!111!!11

        //[Test, Order(5)]
        //public void GetStatusCodeTryToDeleteFileFromArchiverDepository()
        //{
        //    Assert.AreEqual(FileRequestsService.GetStatusCodeDeleteFileFromArchivedRepositoryFail(), 403);
        //}

        //[Test, Order(6)]
        //public void GetErrorMessage()
        //{
        //    Assert.AreEqual(FileRequestsService.GetStausCodeDeleteFileFromRepository(), 204);
        //}
    }
}
