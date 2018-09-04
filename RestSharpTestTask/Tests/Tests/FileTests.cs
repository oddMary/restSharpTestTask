using GitLabAPI.enums;
using GitLabAPI.Factories;
using GitLabAPI.Features;
using GitLabAPI.Builders.JsonBodies;
using NUnit.Framework;
using RestSharp;
using static GitLabAPI.GlobalParameters;
using GitLabAPI.Services;
using NUnit.Allure.Core;

namespace Tests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class FileTests
    {
        RestClient Client;

        public string _fileName = "wtfFile";
        public string _branch = "master";
        public string _content = "content";
        public string _commitMessage = "commitMessage";

        public string _errorMessageUploadFileWithoutCommitMessage = "commit_message is missing, commit_message is empty, content is missing";
        public string _errorMessageUploadFileIncorrectBrunch = "You can only create or edit files when you are on a branch";
        public string _errorMessageUploadFileWithExistedName = "A file with this name already exists";

        [OneTimeSetUp]
        public void SetUpServiceObject()
        {
            Client = ClientFactory.GetInstance();
        }

        [Test]
        public void TestUploadFileWithoutCommitMessage()
        {
            object json = new FileJsonBody(_fileName, _branch); 

            RestRequest GetRequest = RequestFactory.FileRequest(_requestUrlFile, Method.POST, _projectId, _fileName, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string error = JsonDeserializer.ReturnJsonValue("error", RestResponse); ;

            AssertService.AssertEqual(_errorMessageUploadFileWithoutCommitMessage, error);
        }

        [Test]
        public void TestUploadFileWithoutSelectBranch()
        {
            object json = new FileJsonBodyChield(_fileName, _commitMessage, _commitMessage);

            RestRequest GetRequest = RequestFactory.FileRequest(_requestUrlFile, Method.POST, _projectId, _fileName, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string message = JsonDeserializer.ReturnJsonValue("message", RestResponse); ;

            AssertService.AssertEqual(_errorMessageUploadFileIncorrectBrunch, message);
        }

        [Test]
        public void TestAddFile()
        {
            var obj = YamlDeserializer.DDTObjects(GetFilePath.GetPath(DDTFilePath));

            foreach(var item in obj.Items)
            {
                UploadFileToRepo(item.FileName, item.Branch, item.Content, item.CommitMessage, Method.POST, StatusCode.Created.ToString());
            }
        }

        [Test]
        public void TestAddFileWithAlreadyExistedName()
        {
            object json = new FileJsonBodyChield(_fileName, _branch, _content, _commitMessage);

            RestRequest GetRequest = RequestFactory.FileRequest(_requestUrlFile, Method.POST, _projectId, _fileName, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string message = JsonDeserializer.ReturnJsonValue("message", RestResponse); ;

            AssertService.AssertEqual(_errorMessageUploadFileWithExistedName, message);
        }

        [Test]
        public void TestDeleteFileFromRepository()
        {
            var obj = YamlDeserializer.DDTObjects(GetFilePath.GetPath(DDTFilePath));

            foreach (var item in obj.Items)
            {
                UploadFileToRepo(item.FileName, item.Branch, item.Content, item.CommitMessage, Method.DELETE, StatusCode.NoContent.ToString());
            }
        }

        private void UploadFileToRepo(string fileName, string branch, string content, string commit, Method method, string expectedStatusCode)
        {
            object json = new FileJsonBodyChield(fileName, branch, content, commit);

            RestRequest GetRequest = RequestFactory.FileRequest(_requestUrlFile, method, _projectId, fileName, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string statusCode = RestResponse.StatusCode.ToString();

            AssertService.AssertEqual(statusCode, statusCode);
        }
    }
}
