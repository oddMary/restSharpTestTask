using RestSharp;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace GitLabAPI.Features
{
    public class CustomJsonDeserializer
    {
        public static string ReturnJsonValue(string valueKey, IRestResponse response)
        {
            JsonDeserializer jsonDeserialize = new JsonDeserializer();
            var jsonDeserializedObject = jsonDeserialize.Deserialize<Dictionary<string, string>>(response);
            return jsonDeserializedObject[valueKey];
        }        
    }
}
