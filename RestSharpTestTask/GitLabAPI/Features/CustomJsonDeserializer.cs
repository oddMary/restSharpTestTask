using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI.Features
{
    public class CustomJsonDeserializer
    {
        public static string ReturnJsonValue(string valueKey, IRestResponse response)
        {
            JsonDeserializer deserial = new JsonDeserializer();
            var JSONObj = deserial.Deserialize<Dictionary<string, string>>(response);
            return JSONObj[valueKey];
        }        
    }
}
