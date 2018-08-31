using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabAPI.Services
{
    public class AssertService
    {
        public static void AreEqual(string expected, string actual)
        {
            Assert.AreEqual(expected, actual);
        }
    }
}
