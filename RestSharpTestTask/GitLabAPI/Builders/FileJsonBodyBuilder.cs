using GitLabAPI.JsonBodies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI.Builders
{
    class FileJsonBodyBuilder
    {
        FileJsonBody fileJsonBody = new FileJsonBody();

        public FileJsonBodyBuilder SetFilePath(string filePath)
        {
            fileJsonBody.file_path = filePath;
            return this;
        }

        public FileJsonBodyBuilder SetBranch(string branch)
        {
            fileJsonBody.branch = branch;
            return this;
        }

        public FileJsonBodyBuilder SetContetn(string content)
        {
            fileJsonBody.content = content;
            return this;
        }

        public FileJsonBodyBuilder SetCommitMessage(string commitMessage)
        {
            fileJsonBody.commit_message = commitMessage;
            return this;
        }

        public FileJsonBody Build()
        {
            return fileJsonBody;
        }
    }
}
