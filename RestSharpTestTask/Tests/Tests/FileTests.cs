using GitLabAPI.enums;
using GitLabAPI.Factories;
using GitLabAPI.Features;
using GitLabAPI.JsonBodies;
using GitLabAPI.Services;
using NUnit.Framework;
using RestSharp;
using static GitLabAPI.GlobalParameters;

namespace Tests.Tests
{
    [TestFixture]
    class FileTests
    {
        RestClient Client;

        public string _fileName = "wtfFile";
        public string _branch = "master";
        public string _content = "content";
        public string _commitMessage = "commitMessage";

        public string _errorMessageUploadFileWithoutCommitMessage = "commit_message is missing, content is missing";
        public string _errorMessageUploadFileIncorrectBrunch = "You can only create or edit files when you are on a branch";
        public string _errorMessageUploadFileWithExistedName = "A file with this name already exists";

        [OneTimeSetUp]
        public void SetUpServiceObject()
        {
            Client = CreateClient.GetNewClient(BASE_URL);
        }

        [Test]
        public void TestUploadFileWithoutCommitMessage()
        {
            object json = new FileJsonBody(_fileName, _branch);

            RestRequest GetRequest = RequestFactory.FileRequest(_requestUrlFile, Method.POST, _projectId, _fileName, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string error = JsonDeserializer.ReturnJsonValue("error", RestResponse); ;

            AssertService.AreEqual(_errorMessageUploadFileWithoutCommitMessage, error);
        }

        [Test]
        public void TestUploadFileWithoutSelectBrunch()
        {
            object json = new FileJsonBodyChield(_fileName, _commitMessage);

            RestRequest GetRequest = RequestFactory.FileRequest(_requestUrlFile, Method.POST, _projectId, _fileName, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string message = JsonDeserializer.ReturnJsonValue("message", RestResponse); ;

            AssertService.AreEqual(_errorMessageUploadFileIncorrectBrunch, message);
        }

        [Test]
        public void TestAddFile()
        {
            var obj = YamlDeserializer.DDTObjects();

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

            AssertService.AreEqual(_errorMessageUploadFileWithExistedName, message);
        }

        [Test]
        public void TestDeleteFileFromRepository()
        {
            var obj = YamlDeserializer.DDTObjects();

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

            AssertService.AreEqual(statusCode, statusCode);
        }
    }
}
