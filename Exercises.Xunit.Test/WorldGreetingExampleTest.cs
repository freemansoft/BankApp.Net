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
            Mock<LanguageTranslator> myTranslator = new Mock<LanguageTranslator>();
            WorldGreetingExample testObject = new WorldGreetingExample(myTranslator.Object);
            Exception ex = Assert.Throws<ArgumentNullException>(() => testObject.setContactName(null));
        }


        [Fact]
        public void TestSpanish()
        {
            Mock<LanguageTranslator> myTranslator = new Mock<LanguageTranslator>();
            myTranslator.Setup(
                c => c.translateFromEnglish(It.Is<string>(s => s.Contains("hello"))))
                .Returns("hola");

            // given we wish to say hello
            WorldGreetingExample testObject = new WorldGreetingExample(myTranslator.Object);
            // when we meet someone
            testObject.setContactName("smith");
            // then It should say "Hello" "ContactName" when I greet them
            Assert.Equal("hola smith".ToUpper(), testObject.sayGreeting().ToUpper(), true);
        }

    }
}
