
namespace GitLabAPI.JsonBodies
{
    public class FileJsonBody
    {
        public string file_path { get; set; }
        public string branch { get; set; }

        public FileJsonBody() { }

        public FileJsonBody(string filePath)
        {
            this.file_path = filePath;
        }

        public FileJsonBody(string filePath, string branch)
        {
            this.file_path = filePath;
            this.branch = branch;
        }
    }
}
