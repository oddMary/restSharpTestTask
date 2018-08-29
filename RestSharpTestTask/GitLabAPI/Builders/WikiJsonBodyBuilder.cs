using GitLabAPI.JsonBodies;

namespace GitLabAPI.Builders
{
    public class WikiJsonBodyBuilder
    {
        WikiJsonBody WikiJsonBody = new WikiJsonBody();

        public WikiJsonBodyBuilder SetContent(string content)
        {
            WikiJsonBody.content = content;
            return this;
        }

        public WikiJsonBodyBuilder SetTitle(string title)
        {
            WikiJsonBody.title = title;
            return this;
        }

        public WikiJsonBody Build()
        {
            return WikiJsonBody;
        }
    }
}
