using System;
using Xunit;
using Moq;

namespace Exercises.Xunit.Test
{
    public class Example_WorldGreetingTest
    {
        [Fact]
        public void Example_WorldGreeting_NoTranslatorProvided()
        {
            // given we wish to say hello
            Exception ex = Assert.Throws<ArgumentNullException>(() => new WorldGreetingExample(null));
        }

        [Fact]
        public void Example_WorldGreeting_NoNameProvided()
        {
            Mock<ILanguageTranslator> myTranslator = new Mock<ILanguageTranslator>();
            WorldGreetingExample testObject = new WorldGreetingExample(myTranslator.Object);
            Exception ex = Assert.Throws<ArgumentNullException>(() => testObject.SetContactName(null));
        }


        [Fact]
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
            Assert.Equal("hola smith".ToUpper(), testObject.SayGreeting().ToUpper(), true);
            testObject.SetLanguage("EN");
            Assert.Equal("hello smith".ToUpper(), testObject.SayGreeting().ToUpper(), true);
        }

    }
}
