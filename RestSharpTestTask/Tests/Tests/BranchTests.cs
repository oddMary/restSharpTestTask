using NUnit.Framework;
using GitLabAPI.enums;
using RestSharp;
using GitLabAPI.Factories;
using static GitLabAPI.GlobalParameters;
using GitLabAPI.Features;
using GitLabAPI.KDTData;
using NUnit.Allure.Core;

namespace Tests.Tests
{
    [TestFixture]
    [AllureNUnit]
    class BranchTests
    {
        RestClient Client;

        //public string _newBranch = RandomGenerator.RandomString();
        public string _newBranch = "newBranch";
        public string _branch = "master";

        [OneTimeSetUp]
        public void SetUpServiceObject()
        {
            Client = ClientFactory.GetInstance();
        }

        [Test]
        public void TestCreateNewBranch()
        {
            var obj = YamlDeserializer.KDTObjects(GetFilePath.GetPath(KDTFilePathAdd));
            foreach(var item in obj.Action)
            {
                KeywordDrivenTesting.PerformAction(item.name, Client, item.value, StatusCode.Created, _newBranch);
            }
        }

        [Test]
        public void TestDeleteBranch()
        {
            var obj = YamlDeserializer.KDTObjects(GetFilePath.GetPath(KDTFilePathDelete));
            foreach (var item in obj.Action)
            {
                KeywordDrivenTesting.PerformAction(item.name, Client, item.value, StatusCode.NoContent, _newBranch);
            }
        }
    }
}
