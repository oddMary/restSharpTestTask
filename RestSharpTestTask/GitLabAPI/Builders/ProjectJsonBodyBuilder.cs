using GitLabAPI.JsonBodies;
using GitLabAPI.Tool;

namespace GitLabAPI.Builders
{
    public class ProjectJsonBodyBuilder
    {
        ProjectJsonBody ProjectJsonBody = new ProjectJsonBody();
        private static readonly Logger _logger = new Logger(typeof(ProjectJsonBodyBuilder));

        public ProjectJsonBodyBuilder SetDescription(string description)
        {
            _logger.Info($"Adding \"description\" {description} to json body");
            ProjectJsonBody.description = description;
            return this;
        }

        public ProjectJsonBodyBuilder SetName(string name)
        {
            _logger.Info($"Adding \"name\" {name} to json body");
            ProjectJsonBody.name = name;
            return this;
        }

        public ProjectJsonBody Build()
        {
            _logger.Info($"Build json body");
            return ProjectJsonBody;
        }
    }
}
