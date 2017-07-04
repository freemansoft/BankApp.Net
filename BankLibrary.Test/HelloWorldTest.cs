﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankLibrary.Test
{
    [TestClass]
    public class HelloWorldTest
    {
        [TestMethod]
        public void TestSayHellowToSomeone()
        {
            // given we wish to say hello
            HelloWorld testObject = new HelloWorld();
            // when we meet someone
            testObject.seContactName("smith");
            // then It should say "Hello" "ContactName" when I greet them
            Assert.AreEqual("hello smith", testObject.sayHello(), true);
        }
    }
}
