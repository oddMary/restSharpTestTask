using System.IO;
using Tests.DDTData;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static GitLabAPI.GlobalParameters;

namespace GitLabAPI.Features
{
    public class YamlDeserializer
    {
        public static DDTUploadFileList DDTObjects()
        {
            string StringFile = File.ReadAllText(GetFilePath.GetPath(DDTFilePath));            

            StringReader FileYml = new StringReader(StringFile);

            var deserialize = new DeserializerBuilder().WithNamingConvention(new CamelCaseNamingConvention()).Build();
            return deserialize.Deserialize<DDTUploadFileList>(FileYml);
        }
    }
}
