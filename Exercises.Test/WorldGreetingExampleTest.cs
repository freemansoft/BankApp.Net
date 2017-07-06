using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Exercises.Test
{
    [TestClass]
    public class WorldGreetingExmapleTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WorldGreetingExample_NoTranslatorProvided()
        {
            // given we wish to say hello
            WorldGreetingExample testObject = new WorldGreetingExample(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WorldGreetingExample_NoNameProvided()
        {
            Mock<LanguageTranslator> myTranslator = new Mock<LanguageTranslator>();
            WorldGreetingExample testObject = new WorldGreetingExample(myTranslator.Object);
            testObject.setContactName(null);
        }

        [TestMethod]
        public void WorldGreetingExample_TestSpanish()
        {
            Mock<LanguageTranslator> myTranslator = new Mock<LanguageTranslator>();
            myTranslator.Setup(
                c => c.translateFromEnglish(
                    It.Is<string>(s => s.Contains("hello"))))
                .Returns("hola");

            // given we wish to say hello
            WorldGreetingExample testObject = new WorldGreetingExample(myTranslator.Object);
            // when we meet someone
            testObject.setContactName("smith");
            // then It should say "Hello" "ContactName" when I greet them
            Assert.AreEqual("hola smith".ToUpper(), testObject.sayGreeting().ToUpper(), true);
        }
    }
}
