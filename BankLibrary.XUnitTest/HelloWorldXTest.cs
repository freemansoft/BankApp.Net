using System;
using Xunit;

namespace BankLibrary.XUnitTest
{
    public class HelloWorldXTest
    {
        [Fact]
        public void TestMethod1()
        {
            // given we wish to say hello
            HelloWorld testObject = new HelloWorld();
            // when we meet someone
            testObject.seContactName("Smith");
            // then It should say "Hello" "ContactName" when I greet them
            Assert.Equal("hello smith", testObject.sayHello(), true);

        }
    }
}
