using RestSharp;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace GitLabAPI.Features
{
    public class JsonDeserializer
    {
        public static string ReturnJsonValue(string valueKey, IRestResponse response)
        {
            RestSharp.Deserializers.JsonDeserializer jsonDeserialize = new RestSharp.Deserializers.JsonDeserializer();
            var jsonDeserializedObject = jsonDeserialize.Deserialize<Dictionary<string, string>>(response);
            return jsonDeserializedObject[valueKey];
        }        
    }
}
