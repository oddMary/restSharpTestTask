using GitLabAPI.enums;
using GitLabAPI.Services;
using NUnit.Framework;
using RestSharp;

namespace GitLabAPI
{
    [TestFixture]
    class ProjectTests
    {
        ProjectRequestsService ProjectRequestService;
        FileRequestsService FileRequestsService;

        public string _description = "description";
        public string _projectName = "omgProject";
        public string _newProjectName = "omgwtfProject";
        public string _wikiContent = "wikiContent";
        public string _wikiTitle = "wikiTitle";
        public string _fileName = "fileName";
        public string _commitMessage = "commitMessage";

        [OneTimeSetUp]
        public void SetUpServiceObject()
        {
            ProjectRequestService = new ProjectRequestsService();
            FileRequestsService = new FileRequestsService();
        }

        [Test, Order(1)]
        public void TestGetNameSpaces()
        {
            Assert.AreEqual(ProjectRequestService.GetNamespacesStatusCode(), (int)StatusCode.OK);
        }

        [Test, Order(2)]
        public void TestAddProject()
        {
            Assert.AreEqual(ProjectRequestService.GetNameOfNewProject(_description, _projectName), _projectName);
        }

        [Test, Order(3)]
        public void TestUpdateProjectName()
        {
            Assert.AreEqual(ProjectRequestService.GetNameOfUpdatedProject(
                GlobalParameters._requestUrlUpdateProject, Method.PUT, _description, _newProjectName), _newProjectName);
        }

        [Test, Order(4)]
        public void TestArchiveProject()
        {
            Assert.AreEqual(ProjectRequestService.GetStatusCodeArchiveProject(
                GlobalParameters._requestUrlArchived, Method.POST), (int)StatusCode.CREATED);
        }

        [Test, Order(5)]
        public void TestDeleteFileFromArchivedRepository()
        {
            Assert.AreEqual(FileRequestsService.GetStatusCodeDeleteFileFromArchivedRepository(
                GlobalParameters._requestUrlFile, Method.POST, GlobalParameters._projectId, _fileName, _commitMessage),
                (int)StatusCode.FORBIDEN);
        }

        [Test, Order(7)]
        public void TestUnarchiveProject()
        {
            Assert.AreEqual(ProjectRequestService.GetStatusCodeUnarchiveProject(
                GlobalParameters._requestUrlUnarchived, Method.POST), (int)StatusCode.CREATED);
        }

        [Test, Order(8)]
        public void TestCreateWikiPage()
        {
            Assert.AreEqual(ProjectRequestService.GetTitleCreatedWikiPage(
                GlobalParameters._requestUrlWiki, Method.POST, _wikiContent, _wikiTitle), _wikiTitle);
        }

        [Test, Order(9)]
        public void TestDeleteWikiPagel()
        {
            Assert.AreEqual(ProjectRequestService.GetStatusCodeDeleteWikiPage(
                GlobalParameters._requestUrlWikiDelete, Method.DELETE, _wikiContent, _wikiTitle), (int)StatusCode.DELETE);
        }

        [Test, Order(10)]
        public void TestDeleteProject()
        {
            Assert.AreEqual(ProjectRequestService.GetStatusCodeDeleteProject(
                GlobalParameters._requestUrlUpdateProject, Method.DELETE), (int)StatusCode.DELETE_PROJECT);
        }
    }
}
