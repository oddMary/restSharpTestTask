using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI.JsonBodies
{
    class FileJsonBody
    {
        public string file_path { get; set; }
        public string branch { get; set; }
        public string content { get; set; }
        public string commit_message { get; set; }
    }
}
