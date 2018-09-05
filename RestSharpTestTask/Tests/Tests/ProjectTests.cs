using GitLabAPI.Builders;
using GitLabAPI.enums;
using GitLabAPI.Factories;
using GitLabAPI.Features;
using GitLabAPI.Builders.JsonBodies;
using GitLabAPI.Services;
using NUnit.Framework;
using RestSharp;
using static GitLabAPI.GlobalParameters;
using NUnit.Allure.Core;
using GitLabAPI.Tool;

namespace Tests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class ProjectTests
    {
        RestClient Client;
        ProjectJsonBodyBuilder ProjectJsonBody => new ProjectJsonBodyBuilder();
        WikiJsonBodyBuilder WikiJsonBody => new WikiJsonBodyBuilder();
        private static readonly Logger _logger = new Logger(typeof(ProjectTests));

        public int NewProject { get; set; }

        public string _description = "description";
        public string _branch = "master";
        public string _projectName = "omgWTF1233w6434yw45werwatew6";
        public string _newProjectName = "omgwtfNew34y34y34y3OMGProjerweyct12wetsweyw313";
        public string _wikiContent = "wikiContent";
        public string _wikiTitle = "wikiTitle";
        public string _fileName = "fileNameWTF1234135423";
        public string _commitMessage = "commitMessage";

        [OneTimeSetUp]
        public void SetUpServiceObject()
        {
            Client = ClientFactory.GetInstance();
        }

        [Test]
        public void TestGetNameSpaces()
        {
            RestRequest GetRequest = RequestFactory.CustomRequest(_requestUrlNamespaces, Method.GET);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            _logger.Info($"Response {RestResponse.ResponseUri} received");
            string statusCode = RestResponse.StatusCode.ToString();

            AssertService.AssertEqual(StatusCode.Ok.ToString().ToUpper(), statusCode);
        }

        [Test]
        public void TestAddProject()
        {
            object json = ProjectJsonBody.SetDescription(_description).SetName(_projectName).Build();

            RestRequest GetRequest = RequestFactory.ProjectRequest("projects", Method.POST, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            _logger.Info($"Response {RestResponse.ResponseUri} received");
            //Set project id
            NewProject = int.Parse(JsonDeserializer.ReturnJsonValue("id", RestResponse));
            string name = JsonDeserializer.ReturnJsonValue("name", RestResponse); ;

            AssertService.AssertEqual(_projectName, name);
        }

        [Test]
        public void TestRenameProject()
        {
            object json = ProjectJsonBody.SetDescription(_description).SetName(_newProjectName).Build();

            RestRequest GetRequest = RequestFactory.ProjectRequestWithJson(_requestUrlUpdateProject, Method.PUT, NewProject, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            _logger.Info($"Response {RestResponse.ResponseUri} received");
            string name = JsonDeserializer.ReturnJsonValue("name", RestResponse); ;

            AssertService.AssertEqual(_newProjectName, name);
        }

        [Test]
        public void TestArchiveProject()
        {
            RestRequest GetRequest = RequestFactory.ProjectRequest(_requestUrlArchived, Method.POST, _projectId);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            _logger.Info($"Response {RestResponse.ResponseUri} received");
            string statusCode = RestResponse.StatusCode.ToString();

            AssertService.AssertEqual(StatusCode.Created.ToString(), statusCode);
        }

        [Test]
        public void TestToUploadFileToArchivedRepository()
        {
            object json = new FileJsonBodyChield(_fileName, _branch, _commitMessage, _commitMessage);

            RestRequest GetRequest = RequestFactory.FileRequest(_requestUrlFile, Method.POST, _projectId, _fileName, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            _logger.Info($"Response {RestResponse.ResponseUri} received");
            string statusCode = RestResponse.StatusCode.ToString();

            AssertService.AssertEqual(StatusCode.Forbidden.ToString(), statusCode);
        }

        [Test]
        public void TestUnarchiveProject()
        {
            RestRequest GetRequest = RequestFactory.ProjectRequest(_requestUrlUnarchived, Method.POST, _projectId);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            _logger.Info($"Response {RestResponse.ResponseUri} received");
            string statusCode = RestResponse.StatusCode.ToString();

            AssertService.AssertEqual(StatusCode.Created.ToString(), statusCode);
        }

        [Test]
        public void TestCreateWikiPage()
        {
            object json = WikiJsonBody.SetContent(_wikiContent).SetTitle(_wikiTitle).Build();

            RestRequest GetRequest = RequestFactory.ProjectRequestWithJson(_requestUrlWiki, Method.POST, NewProject, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            _logger.Info($"Response {RestResponse.ResponseUri} received");
            string title = JsonDeserializer.ReturnJsonValue("title", RestResponse); ;

            AssertService.AssertEqual(_wikiTitle, title);
        }

        [Test]
        public void TestDeleteWikiPage()
        {
            RestRequest GetRequest = RequestFactory.ProjectRequest(_requestUrlWikiDelete, Method.DELETE, NewProject);
            GetRequest.AddUrlSegment("slug", _wikiTitle);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            _logger.Info($"Response {RestResponse.ResponseUri} received");
            string statusCode = RestResponse.StatusCode.ToString();

            AssertService.AssertEqual(StatusCode.NoContent.ToString(), statusCode);
        }

        [Test]
        public void TestToDeleteProject()
        {
            RestRequest GetRequest = RequestFactory.ProjectRequest(_requestUrlUpdateProject, Method.DELETE, NewProject);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            _logger.Info($"Response {RestResponse.ResponseUri} received");
            string statusCode = RestResponse.StatusCode.ToString();

            AssertService.AssertEqual(StatusCode.Accepted.ToString(), statusCode);
        }

        [OneTimeTearDown]
        public void DeleteTestFile()
        {
            object json = new FileJsonBodyChield(_fileName, _branch, _commitMessage, _commitMessage);

            RestRequest GetRequest = RequestFactory.FileRequest(_requestUrlFile, Method.DELETE, _projectId, _fileName, json);
            IRestResponse RestResponse = Client.Execute(GetRequest);
        }
    }
}
