using System;
using System.Configuration;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace UnitTestProject1
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\BadFileName.txt";
        private string _GoodFileName;
        private const string FILE_NAME = @"FileToDeploy.txt";

        public TestContext TestContext { get; set; }

        #region Test Initialize e Cleanup

        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExists"))
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Creating File: {_GoodFileName}");
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExists"))
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Deleting File: {_GoodFileName}");
                    File.Delete(_GoodFileName);
                }
            }
        }

        #endregion

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        [TestMethod]
        [Description("Check to see if a file does exist")]
        [Owner("AlexandreCardoso")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesExists()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Act
            TestContext.WriteLine($"Testing File: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);


            //Assert
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Check to see if a file does exist")]
        [Owner("AlexandreCardoso")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesExistsSimpleMessage()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Act
            TestContext.WriteLine($"Testing File: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);


            //Assert
            Assert.IsTrue(fromCall, "File exist");
        }

        [TestMethod]
        [Owner("AlexandreCardoso")]
        [DeploymentItem(FILE_NAME)]
        public void FineNameDoesExistUsingDeplymentItem()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            string fileName;
            bool fromCall;

            //Act
            fileName = $@"{TestContext.DeploymentDirectory}\{FILE_NAME}";
            TestContext.WriteLine($"Testing File: {fileName}");
            fromCall = fp.FileExists(fileName);


            //Assert
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Check to see if a file does NOT exist")]
        [Owner("AlexandreCardoso")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesNotExists()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;

            //Act
            fromCall = fp.FileExists(BAD_FILE_NAME);

            //Assert
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Owner("AlexandreCardoso")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentException()
        {
            //Arrange
            FileProcess fp = new FileProcess();

            //Act
            fp.FileExists(string.Empty);

            //Assert
        }

        [TestMethod]
        [Owner("AnaLuiza")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentException_UsingTryCatch()
        {
            //Arrange
            FileProcess fp = new FileProcess();

            //Act
            try
            {
                fp.FileExists(string.Empty);
            }
            catch (ArgumentNullException)
            {
                //The test was a success.
                return;
            }

            //Assert
            Assert.Fail("Fail Expected");
        }

        [TestMethod]
        [Timeout(3100)]
        public void SimulateTimeout()
        {
            System.Threading.Thread.Sleep(3000);
        }
    }
}
