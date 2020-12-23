using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using MyClasses.PersonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class AssertClassTest
    {
        #region AreEqual/AreNotEqual Tests
        [TestMethod]
        [Owner("AlexandreCardoso")]
        public void AreEqualTest()
        {
            string str1 = "Alexandre";
            string str2 = "Alexandre";

            Assert.AreEqual(str1, str2);
        }

        [TestMethod]
        [Owner("AlexandreCardoso")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualCaseSensitiveTest()
        {
            string str1 = "Alexandre";
            string str2 = "alexandre";

            Assert.AreEqual(str1, str2, false);
        }

        [TestMethod]
        [Owner("AlexandreCardoso")]
        public void AreNotEqualTest()
        {
            string str1 = "Alexandre";
            string str2 = "Ana Luiza";

            Assert.AreNotEqual(str1, str2);
        }

        #endregion

        #region AreSame/AreNotSame Tests

        [TestMethod]
        public void AreSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]
        public void AreNotSameTest()
        {
            FileProcess x = new FileProcess();
            FileProcess y = new FileProcess();

            Assert.AreNotSame(x, y);
        }

        #endregion

        #region IsInstanceOfType Tests

        [TestMethod]
        [Owner("AlexandreCardoso")]
        public void IsInstanceOfTypeTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("Alexandre", "Cardoso", true);

            Assert.IsInstanceOfType(per, typeof(Supervisor));
        }

        [TestMethod]
        [Owner("AlexandreCardoso")]
        public void IsNullTest()
        {
            PersonManager mgr = new PersonManager();
            Person per;

            per = mgr.CreatePerson("", "Cardoso", true);

            Assert.IsNull(per);
        }

        #endregion
    }
}
