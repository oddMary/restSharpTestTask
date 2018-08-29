using GitLabAPI.JsonBodies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI.Builders
{
    class UserJsonBodyBuilder
    {
        private UserJsonBody UserStatusJsonBody = new UserJsonBody();

        public UserJsonBodyBuilder SetMessage(string messge)
        {
            UserStatusJsonBody.message = messge;
            return this;
        }

        public UserJsonBodyBuilder SetEmail(string email)
        {
            UserStatusJsonBody.email = email;
            return this;
        }

        public UserJsonBody Build()
        {
            return UserStatusJsonBody;
        }
    }
}
