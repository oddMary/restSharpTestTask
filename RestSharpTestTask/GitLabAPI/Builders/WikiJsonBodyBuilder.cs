using GitLabAPI.JsonBodies;
using GitLabAPI.Tool;

namespace GitLabAPI.Builders
{
    public class WikiJsonBodyBuilder
    {
        WikiJsonBody WikiJsonBody = new WikiJsonBody();
        private static readonly Logger _logger = new Logger(typeof(WikiJsonBodyBuilder));

        public WikiJsonBodyBuilder SetContent(string content)
        {
            _logger.Info($"Adding \"content\" {content} to json body");
            WikiJsonBody.content = content;
            return this;
        }

        public WikiJsonBodyBuilder SetTitle(string title) 
        {
            _logger.Info($"Adding \"title\" {title} to json body");
            WikiJsonBody.title = title;
            return this;
        }

        public WikiJsonBody Build()
        {
            _logger.Info($"Build json body");
            return WikiJsonBody;
        }
    }
}
