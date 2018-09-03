using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Exercises.Test
{
    /// <summary>
    /// Example test file for HelloWorld.cs
    /// </summary>
    [TestClass]
    public class HelloWorldExampleTest
    {
        [TestMethod]
        public void Example_HelloWorld_SayHelloToNoone()
        {
            // given we wish to say hello
            HelloWorldExample testObject = new HelloWorldExample();
            // when we meet no one
            testObject.SetContactName(null);
            // then just say hell with no errors or trailing spaces
            Assert.AreEqual("hello", testObject.SayHello(), true);
        }

        [TestMethod]
        public void Example_HelloWorld_SayHelloToSomeone()
        {
            // given we wish to say hello
            HelloWorldExample testObject = new HelloWorldExample();
            // when we meet someone
            testObject.SetContactName("smith");
            // then It should say "Hello" "ContactName" when I greet them
            Assert.AreEqual("hello smith", testObject.SayHello(), true);
        }
    }
}

