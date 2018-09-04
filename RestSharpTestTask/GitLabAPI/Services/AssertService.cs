using GitLabAPI.Tool;
using NUnit.Framework;

namespace GitLabAPI.Services
{
    public class AssertService
    {
        private static readonly Logger _logger = new Logger(typeof(AssertService));

        public delegate void AssertDelegate(string expected, string actual);
        public static AssertDelegate AssertEqual = (expected, actual) => 
        {
            _logger.Info($"Assert that expected result : {expected} are equal to actual: {actual}");
            Assert.AreEqual(expected, actual); };
    }
}
