using System;
using Xunit;
using Moq;

namespace Exercises.Xunit.Test
{
    public class HelloWorldExampleTest
    {
        [Fact]
        public void SayHelloToSomeone()
        {
            // given we wish to say hello
            HelloWorldExample testObject = new HelloWorldExample();
            // when we meet someone
            testObject.seContactName("Smith");
            // then It should say "Hello" "ContactName" when I greet them
            Assert.Equal("hello smith", testObject.sayHello(), true);

        }
    }
}
