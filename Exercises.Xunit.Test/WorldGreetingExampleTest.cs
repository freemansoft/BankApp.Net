using System;
using Xunit;
using Moq;

namespace Exercises.Xunit.Test
{
    public class WorldGreetingExampleTest
    {
        [Fact]
        public void NoTranslatorProvided()
        {
            // given we wish to say hello
            Exception ex = Assert.Throws<ArgumentNullException>(() => new WorldGreetingExample(null));
        }

        [Fact]
        public void NullName()
        {
            Mock<ILanguageTranslator> myTranslator = new Mock<ILanguageTranslator>();
            WorldGreetingExample testObject = new WorldGreetingExample(myTranslator.Object);
            Exception ex = Assert.Throws<ArgumentNullException>(() => testObject.SetContactName(null));
        }


        [Fact]
        public void TestSpanish()
        {
            Mock<ILanguageTranslator> myTranslator = new Mock<ILanguageTranslator>();
            myTranslator.Setup(
                c => c.TranslateFromEnglish(It.Is<string>(s => s.Contains("hello"))))
                .Returns("hola");

            // given we wish to say hello
            WorldGreetingExample testObject = new WorldGreetingExample(myTranslator.Object);
            // when we meet someone
            testObject.SetContactName("smith");
            // then It should say "Hello" "ContactName" when I greet them
            Assert.Equal("hola smith".ToUpper(), testObject.SayGreeting().ToUpper(), true);
        }

    }
}
