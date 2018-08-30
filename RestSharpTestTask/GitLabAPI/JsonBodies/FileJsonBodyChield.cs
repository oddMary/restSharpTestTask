
namespace GitLabAPI.JsonBodies
{
    public class FileJsonBodyChield : FileJsonBody
    {
        public string content { get; set; }
        public string commit_message { get; set; }

        public FileJsonBodyChield() : base() { }

        public FileJsonBodyChield(string filePath, string content) : base(filePath)
        {
            base.file_path = filePath;
            this.content = content;
        }

        public FileJsonBodyChield(string filePath, string branch,string content, string commit_message) :base(filePath, branch)
        {
            base.file_path = filePath;
            base.branch = branch;
            this.content = content;
            this.commit_message = commit_message;
        }
    }
}
