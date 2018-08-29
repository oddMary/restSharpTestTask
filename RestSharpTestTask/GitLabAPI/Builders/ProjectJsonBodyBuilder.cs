using GitLabAPI.JsonBodies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI.Builders
{
    public class ProjectJsonBodyBuilder
    {
        ProjectJsonBody Project = new ProjectJsonBody();

        public ProjectJsonBodyBuilder SetDescription(string description)
        {
            Project.description = description;
            return this;
        }

        public ProjectJsonBodyBuilder SetName(string name)
        {
            Project.name = name;
            return this;
        }

        public ProjectJsonBody Build()
        {
            return Project;
        }
    }
}
