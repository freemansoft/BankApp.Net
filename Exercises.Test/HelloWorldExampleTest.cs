using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Exercises.Test
{
    [TestClass]
    public class HelloWorldExampleTest
    {
        [TestMethod]
        public void HelloWorldExample_SayHelloToSomeone()
        {
                        // given we wish to say hello
            HelloWorldExample testObject = new HelloWorldExample();
                        // when we meet someone
            testObject.seContactName("smith");
                        // then It should say "Hello" "ContactName" when I greet them
            Assert.AreEqual("hello smith", testObject.sayHello(), true);
        }
    }
}

