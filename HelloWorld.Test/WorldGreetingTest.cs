using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HelloWorld.Test
{
    [TestClass]
    public class WorldGreetingTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNoTranslatorProvided()
        {
            // given we wish to say hello
            WorldGreeting testObject = new WorldGreeting(null);
        }

        [TestMethod]
        public void TestWorldGreetingSpanish()
        {
            Mock<LanguageTranslator> myTranslator = new Mock<LanguageTranslator>();
            myTranslator.Setup(
                c => c.translateFromEnglish(
                    It.Is<string>(s => s.Contains("hello"))))
                .Returns("hola");

            // given we wish to say hello
            WorldGreeting testObject = new WorldGreeting(myTranslator.Object);
            // when we meet someone
            testObject.seContactName("smith");
            // then It should say "Hello" "ContactName" when I greet them
            Assert.AreEqual("hola smith".ToUpper(), testObject.sayGreeting().ToUpper(), true);
        }
    }
}
