using GitLabAPI.JsonBodies;

namespace GitLabAPI.Builders
{
    public class ProjectJsonBodyBuilder
    {
        ProjectJsonBody ProjectJsonBody = new ProjectJsonBody();

        public ProjectJsonBodyBuilder SetDescription(string description)
        {
            ProjectJsonBody.description = description;
            return this;
        }

        public ProjectJsonBodyBuilder SetName(string name)
        {
            ProjectJsonBody.name = name;
            return this;
        }

        public ProjectJsonBody Build() => ProjectJsonBody;
    }
}
