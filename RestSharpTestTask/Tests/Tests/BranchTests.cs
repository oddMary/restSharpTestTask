using NUnit.Framework;
using GitLabAPI.enums;
using RestSharp;
using GitLabAPI.Factories;
using static GitLabAPI.GlobalParameters;
using GitLabAPI.Services;

namespace Tests.Tests
{
    [TestFixture]
    class BrunchTests
    {
        RestClient Client;

        public string _newBranch = "newBranch";
        public string _branch = "master";

        [OneTimeSetUp]
        public void SetUpServiceObject()
        {
            Client = CreateClient.GetNewClient(BASE_URL);
        }

        [Test]
        public void TestCreateNewBrunch()
        { 
            RestRequest GetRequest = RequestFactory.BranchRequest(_requestUrlBranch, Method.POST, _projectId, _newBranch);
            GetRequest.AddUrlSegment("branch", _branch);
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string statusCode = RestResponse.StatusCode.ToString();

            AssertService.AreEqual(StatusCode.Created.ToString(), statusCode);
        }

        [Test]
        public void TestDeleteBranch()
        {
            RestRequest GetRequest = RequestFactory.BranchRequest(_requestUrlDeleteBranch, Method.DELETE, _projectId, _newBranch);            
            IRestResponse RestResponse = Client.Execute(GetRequest);
            string statusCode = RestResponse.StatusCode.ToString();

            AssertService.AreEqual(StatusCode.NoContent.ToString(), statusCode.ToString());
        }
    }
}
