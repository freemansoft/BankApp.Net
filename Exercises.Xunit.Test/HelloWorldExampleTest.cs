using System;
using Xunit;
using Moq;

namespace Exercises.Xunit.Test
{
    public class HelloWorldExampleTest
    {
        [Fact]
        public void Example_HelloWorld_SayHelloToNoone()
        {
            // given we wish to say hello
            HelloWorldExample testObject = new HelloWorldExample();
            // when we meet no one
            testObject.SetContactName(null);
            // then just say hell with no errors or trailing spaces
            Assert.Equal("hello", testObject.SayHello(), true);
        }


        [Fact]
        public void Example_HelloWorld_SayHelloToSomeone()
        {
            // given we wish to say hello
            HelloWorldExample testObject = new HelloWorldExample();
            // when we meet someone
            testObject.SetContactName("Smith");
            // then It should say "Hello" "ContactName" when I greet them
            Assert.Equal("hello smith", testObject.SayHello(), true);

        }
    }
}
