using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI.Client
{
    public class CreateClient
    {
        private static RestClient NewClient { get; set; }

        public static RestClient getNewClient(string url)
        {
            return NewClient = new RestClient(url);
        }

        internal static RestClient getNewClient(object bASE_URL)
        {
            throw new NotImplementedException();
        }
    }
}