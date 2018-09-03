using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Exercises.Test
{
    /// <summary>
    /// Empty test file that can be used with HelloWorld.cs
    /// </summary>
    [TestClass]
    public class HelloWorldTest
    {
        [TestMethod]
        public void HelloWorld_SayHelloToSomeone()
        {
            HelloWorld objectUnderTest = new HelloWorld();
            Assert.Inconclusive("not implemented");
        }
    }
}

