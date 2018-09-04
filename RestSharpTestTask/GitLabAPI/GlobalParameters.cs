
namespace GitLabAPI
{
    public class GlobalParameters
    {
        public const string PRIVATE_TOKEN_HEADER_NAME = "Private-Token";
        public const string PRIVATE_TOKEN = "RrNqtH4tfbvwdUa77oxx";

        public const string BASE_URL = "https://gitlab.com/api/v4/";

        public static int _userId = 2709127;
        public static int _projectId = 8156878;

        public static string _requestUrlNamespaces = "namespaces";

        public static string _requestUrlBranch = "projects/{projectId}/repository/branches?branch={newBranch}&ref={branch}";
        public static string _requestUrlDeleteBranch = "projects/{projectId}/repository/branches/{newBranch}";

        public static string _requestUrlFile = "projects/{projectId}/repository/files/{fileName}";

        public static string _requestUrlAddProject = "projects";
        public static string _requestUrlUpdateProject = "projects/{projectId}";
        public static string _requestUrlArchived = "projects/{projectId}/archive";
        public static string _requestUrlUnarchived = "projects/{projectId}/unarchive";
        public static string _requestUrlWiki = "projects/{projectId}/wikis";
        public static string _requestUrlWikiDelete = "projects/{projectId}/wikis/{slug}";

        public static string _requestUrlGetUserState = "users/{userId}";
        public static string _requestUrlUserStatus = "user/status";
        public static string _requestUrlEmails = "user/emails";

        public static string DDTFilePath = "../../Resources/DDTUploadFileTest.yml";
        public static string KDTFilePathAdd = "../../Resources/KDTAddBranchTest.yml";
        public static string KDTFilePathDelete = "../../Resources/KDTDeleteBranchTest.yml";

        public static string nunitConsolePath = "../../../Resources/nunit3-console/nunit3-console.exe";
        public static string testPath = "Tests.exe";
    }
}
