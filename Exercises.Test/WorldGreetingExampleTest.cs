using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Exercises.Test
{
    [TestClass]
    public class WorldGreetingExampleTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Example_WorldGreeting_NoTranslatorProvided()
        {
            // given we wish to say hello
            WorldGreetingExample testObject = new WorldGreetingExample(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Example_WorldGreeting_NoNameProvided()
        {
            Mock<ILanguageTranslator> myTranslator = new Mock<ILanguageTranslator>();
            WorldGreetingExample testObject = new WorldGreetingExample(myTranslator.Object);
            testObject.SetContactName(null);
        }

        [TestMethod]
        public void Example_WorldGreeting_TestSpanish()
        {
            Mock<ILanguageTranslator> myTranslator = new Mock<ILanguageTranslator>();
            myTranslator.Setup(
                c => c.GenerateHelloGreeting(
                    It.Is<string>(s => s.Contains("SP"))))
                .Returns("hola");
            myTranslator.Setup(
                c => c.GenerateHelloGreeting(
                    It.Is<string>(s => s.Contains("EN"))))
                .Returns("hello");

            // given we wish to say hello
            WorldGreetingExample testObject = new WorldGreetingExample(myTranslator.Object);
            // when we meet someone
            testObject.SetContactName("smith");
            // then It should say "Hello" "ContactName" when I greet them
            testObject.SetLanguage("SP");
            Assert.AreEqual("hola smith".ToUpper(), testObject.SayGreeting().ToUpper(), true);
            testObject.SetLanguage("EN");
            Assert.AreEqual("hello smith".ToUpper(), testObject.SayGreeting().ToUpper(), true);
        }
    }
}
