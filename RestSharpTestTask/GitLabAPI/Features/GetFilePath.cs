using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI.Features
{
    public class GetFilePath
    {
        public static string GetPath(string path)
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var getPath = Path.Combine(outPutDirectory, path);
            return new Uri(getPath).LocalPath;
        }
    }
}
