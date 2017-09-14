using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BankLibrary.Test
{
    [TestClass]
    public class SimpleAccountTest
    {
        [TestMethod]
        public void Simple_NewAccountBalance()
        {
            SimpleAccount objectUnderTest = new BankLibrary.SimpleAccount("Bill", "Gates", Decimal.Zero);
            Assert.AreEqual(Decimal.Zero, objectUnderTest.getCurrentBalance());

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Simple_NewAccountNoFirstName()
        {
            SimpleAccount objectUnderTest = new BankLibrary.SimpleAccount(null, "Gates", Decimal.Zero);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Simple_NewAccountNoLastName()
        {
            SimpleAccount objectUnderTest = new BankLibrary.SimpleAccount("Bill", null, Decimal.Zero);

        }

        [TestMethod]
        public void Simple_Withdrawl()
        {
            SimpleAccount objectUnderTest = new BankLibrary.SimpleAccount("Bill", "Gates", new decimal(200.0));
            objectUnderTest.Debit(new decimal(20.0));
            Assert.AreEqual(new decimal(180.0), objectUnderTest.getCurrentBalance());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Simple_WithdrawlOverdraft()
        {
            SimpleAccount objectUnderTest = new BankLibrary.SimpleAccount("Bill", "Gates", new decimal(200.0));
            objectUnderTest.Debit(new decimal(220.0));
        }

        [TestMethod]
        public void Simple_WithdrawlOverdraftWithEmail()
        {
            SimpleAccount objectUnderTest = new BankLibrary.SimpleAccount("Bill", "Gates", new decimal(200.0));
            Mock<IEmailSender> myMock = new Mock<IEmailSender>();
            myMock.Setup(c => c.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);
            // inject the email sender via setter injection.  mock.Object returns the actual mock
            objectUnderTest.sender = myMock.Object;
            try
            {
                objectUnderTest.Debit(new decimal(220.0));
                // don't need to verify this because it id done above.  this test should only verify one behavior
                //Assert.Fail("should have sent email and then thrown an exception");
            } catch (ArgumentException e)
            {
                Console.WriteLine("overdraft attempt causes email and then exception so this is good "+e);
            }
            // we ate the exception so go back and verify that the mock was invoked to send email
            myMock.Verify(
                m => m.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), 
                Times.Once);
       }

    }
}
