using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class StringAssertClassTest
    {
        [TestMethod]
        [Owner("AlexandreCardoso")]
        public void ContainsTest()
        {
            string str1 = "Alexandre Cardoso";
            string str2 = "Cardoso";

            StringAssert.Contains(str1, str2);
        }

        [TestMethod]
        [Owner("AlexandreCardoso")]
        public void StartsWithTest()
        {
            string str1 = "Alexandre Cardoso";
            string str2 = "Alexandre";

            StringAssert.StartsWith(str1, str2);
        }

        [TestMethod]
        [Owner("AlexandreCardoso")]
        public void IsAllLowerCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");

            StringAssert.Matches("alexandre cardoso", reg);
        }

        [TestMethod]
        [Owner("AlexandreCardoso")]
        public void IsNotAllLowerCaseTest()
        {
            Regex reg = new Regex(@"^([^A-Z])+$");

            StringAssert.DoesNotMatch("Alexandre Cardoso", reg);
        }
    }
}
