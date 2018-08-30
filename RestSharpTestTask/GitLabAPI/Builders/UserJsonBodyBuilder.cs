using GitLabAPI.JsonBodies;

namespace GitLabAPI.Builders
{
    class UserJsonBodyBuilder
    {
        private UserJsonBody UserJsonBody = new UserJsonBody();

        public UserJsonBodyBuilder SetId(int userId)
        {
            UserJsonBody.id = userId;
            return this;
        }

        public UserJsonBodyBuilder SetMessage(string messge)
        {
            UserJsonBody.message = messge;
            return this;
        }

        public UserJsonBodyBuilder SetEmail(string email)
        {
            UserJsonBody.email = email;
            return this;
        }

        public UserJsonBody Build() => UserJsonBody;
    }
}
