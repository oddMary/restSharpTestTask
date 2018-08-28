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
        public static RestClient NewClient(string url) => new RestClient(url)
        {
        };
    }
}