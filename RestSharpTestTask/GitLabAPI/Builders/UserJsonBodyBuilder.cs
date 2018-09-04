using GitLabAPI.JsonBodies;
using GitLabAPI.Tool;

namespace GitLabAPI.Builders
{
    public class UserJsonBodyBuilder
    {
        private UserJsonBody UserJsonBody = new UserJsonBody();
        private static readonly Logger _logger = new Logger(typeof(UserJsonBodyBuilder));

        public UserJsonBodyBuilder SetId(int userId)
        {
            _logger.Info($"Adding \"userId\" {userId} to json body");
            UserJsonBody.id = userId;
            return this;
        }

        public UserJsonBodyBuilder SetMessage(string message)
        {
            _logger.Info($"Adding \"message\" {message} to json body");
            UserJsonBody.message = message;
            return this;
        }

        public UserJsonBodyBuilder SetEmail(string email)
        {

            UserJsonBody.email = email;
            return this;
        }

        public UserJsonBody Build()
        {
            _logger.Info($"Build json body");
            return UserJsonBody;
        }
    }
}
