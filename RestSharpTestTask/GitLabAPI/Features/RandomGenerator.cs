using System.IO;

namespace GitLabAPI.Features
{
    public class RandomGenerator
    {
        public static string RandomString()
        {
            string randomString = Path.GetRandomFileName();
            randomString = randomString.Replace(".", string.Empty);
            return randomString;
        }
    }
}
