using GitLabAPI;
using GitLabAPI.enums;
using GitLabAPI.Services;
using NUnit.Framework;
using RestSharp;

namespace Tests.Tests
{
    [TestFixture]
    class FileTests
    {
        FileRequestsService FileRequestsService;

        public string _fileName = "fileName";
        public string _branch = "master";
        public string _content = "content";
        public string _commitMessage = "commitMessage";

        public string _errorMessageUploadFileWithoutCommit = "commit_message is missing, content is missing";
        public string _errorMessageUploadFileIncorrectBranch = "You can only create or edit files when you are on a branch";
        public string _errorMessageUploadFileWithExistedName = "A file with this name already exists";

        [OneTimeSetUp]
        public void SetUpServiceObject()
        {
            FileRequestsService = new FileRequestsService();
        }

        [Test, Order(1)]
        public void TestUploadFileWithoutCommitMessage()
        {
            Assert.AreEqual(FileRequestsService.GetErrorMessageCreateFileWithoutTheCommitMessage(
                GlobalParameters._requestUrlFile, Method.POST, GlobalParameters._projectId, _fileName, _branch), 
                _errorMessageUploadFileWithoutCommit);
        }

        [Test, Order(2)]
        public void TestUploadFileWithoutSelectBranch()
        {
            Assert.AreEqual(FileRequestsService.GetErrorMessageCreateFileInNotChosenBranch(
                GlobalParameters._requestUrlFile, Method.POST, GlobalParameters._projectId, _fileName, _commitMessage), 
                _errorMessageUploadFileIncorrectBranch);
        }

        [Test, Order(3)]
        public void TestUploadFile()
        {
            Assert.AreEqual(FileRequestsService.GetStatusCodeCreateFileInRepository(
                GlobalParameters._requestUrlFile, Method.POST, GlobalParameters._projectId, _fileName, _branch, _content, _commitMessage), 
                (int)StatusCode.CREATED);
        }

        [Test, Order(4)]
        public void TestUploadFileWithAlreadyExistedName()
        {
            Assert.AreEqual(FileRequestsService.GetErrorMessageCreateFileWithAlreadyExistedName(
                GlobalParameters._requestUrlFile, Method.POST, GlobalParameters._projectId, _fileName, _branch, _content, _commitMessage), 
                _errorMessageUploadFileWithExistedName);
        }

        [Test, Order(6)]
        public void TestDeleteFileFromRepository()
        {
            Assert.AreEqual(FileRequestsService.GetStatusCodeDeleteFileFromRepository(
                GlobalParameters._requestUrlFile, Method.DELETE, GlobalParameters._projectId, _fileName, _branch, _content, _commitMessage), 
                (int)StatusCode.DELETE);
        }
    }
}
