using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GitLabAPI.Wrapper
{
    public class RegexMessage
    {
        public static string RegexWarningMessage(string message)
        {
            string pattern = "[^:,0-9a-zA-Z\\s]";
            Regex regex = new Regex(pattern);
            return regex.Replace(message, "");
        }
    }
}
