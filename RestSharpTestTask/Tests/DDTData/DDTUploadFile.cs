using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Tests.DDTData
{
    public class DDTUploadFile
    {
        public string FileName { get; set; }
        public string Branch { get; set; }
        public string Content { get; set; }
        public string CommitMessage { get; set; }

        //public List<DDTUploadFile> ddtObjects = new List<DDTUploadFile>();
        //DDTUploadFile obj = new DDTUploadFile();

        //public DDTUploadFile CreateObjects()
        //{
        //    //string StringFile = File.ReadAllText("D:/TicketMasterTasks/4/My/restSharpTestTask/RestSharpTestTask/Resources/DDT.yml");
        //    //StringReader FileYml = new StringReader(StringFile);

        //    //var deserialize = new Deserializer();
        //    //return obj = (DDTUploadFile)deserialize.Deserialize(FileYml);
        //}
    }
}
