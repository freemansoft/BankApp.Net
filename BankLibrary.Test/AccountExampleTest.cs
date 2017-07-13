using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankLibrary.Test
{
    /// <summary>
    /// Summary description for AccountExampleTest
    /// </summary>
    [TestClass]
    public class AccountExampleTest
    {
        public AccountExampleTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreateCheckingAccountWithZeroBalance()
        {
            AccountExample testObject = new AccountExample(null);
            testObject.SetFirstName("John");
            testObject.SetLastName("Smith");
            testObject.SetupAccount();

            Assert.IsNotNull(testObject.GetAccountNumber());
            Assert.AreEqual(Decimal.Zero, testObject.GetBalance());

            //
            // TODO: Add test logic here
            //
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckNullFirstName()
        {
            AccountExample testObject = new AccountExample(null);
            testObject.SetFirstName(null);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OverdraftException()
        {
            Mock<IEmailSender> myMock = new Mock<IEmailSender>();
             AccountExample testObject = new AccountExample(null);
            testObject.SetFirstName("Bill").SetLastName("Gates").SetupAccount().Deposit(new decimal(100.0));
            testObject.Debit(new decimal(120.0));
        }

        [TestMethod]
            public void OverdraftEmail()
        {
            Mock<IEmailSender> myMock = new Mock<IEmailSender>();
            myMock.Setup(c => c.sendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);
            AccountExample testObject = new AccountExample(myMock.Object);
            testObject.SetFirstName("Bill").SetLastName("Gates").SetupAccount();
            testObject.Deposit(new decimal(100.0));

           try
            {
                testObject.Debit(new decimal(220.0));
                // don't need to verify this because it id done above.  this test should only verify one behavior
                //Assert.Fail("should have sent email and then thrown an exception");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("overdraft attempt causes email and then exception so this is good " + e);
            }
            // we ate the exception so go back and verify that the mock was invoked to send email
            myMock.Verify(
                m => m.sendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);
        }

    }
}
