using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI.JsonBodies
{
    public class ProjectJsonBody
    {
        public string description { get; set; }
        
        public string name { get; set; }
    }
}
