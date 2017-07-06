using System;
using Xunit;
using Moq;

namespace Exercises.Xunit.Test
{
    public class StringSetExampleTest
    {
        StringSetExample SetUnderTest;

        public StringSetExampleTest()
        {
            SetUnderTest = new StringSetExample();
        }

        [Fact]
        public void Example_StringSet_AddStringToSet()
        {
            int preAddCount = SetUnderTest.Count();
            int afterAddCount = SetUnderTest.Add("aString");
            Assert.Equal(preAddCount + 1, afterAddCount);
        }

        [Fact]
        public void Example_StringSet_SetContainsString()
        {
            SetUnderTest.Add("s1");
            SetUnderTest.Add("s2");
            Assert.True(SetUnderTest.Contains("s1"));
            Assert.True(SetUnderTest.Contains("s2"));
            Assert.False(SetUnderTest.Contains("s3"));
        }

        [Fact]
        public void Example_StringSet_SetContainsStringUsingLinq()
        {
            SetUnderTest.Add("s1");
            SetUnderTest.Add("s2");
            Assert.True(SetUnderTest.ContainsWithLinq("s1"));
            Assert.True(SetUnderTest.ContainsWithLinq("s2"));
            Assert.False(SetUnderTest.ContainsWithLinq("s3"));
        }

        [Fact]
        public void Example_StringSet_RemoveString()
        {
            SetUnderTest.Add("s1");
            SetUnderTest.Add("s2");
            SetUnderTest.Add("s3");
            SetUnderTest.Add("s4");
            int startCount = SetUnderTest.Count();
            // verify does no harm
            SetUnderTest.Remove("sXXX");
            Assert.Equal(startCount, SetUnderTest.Count());
            // interior
            SetUnderTest.Remove("s3");
            Assert.Equal(startCount - 1, SetUnderTest.Count());
            Assert.False(SetUnderTest.Contains("s3"));
            // start
            SetUnderTest.Remove("s1");
            Assert.Equal(startCount - 2, SetUnderTest.Count());
            Assert.False(SetUnderTest.Contains("s1"));
            // end
            SetUnderTest.Remove("s4");
            Assert.Equal(startCount - 3, SetUnderTest.Count());
            Assert.False(SetUnderTest.Contains("s4"));
        }

        [Fact]
        public void Example_StringSet_RemoveStringUsingLinq()
        {
            SetUnderTest.Add("s1");
            SetUnderTest.Add("s2");
            SetUnderTest.Add("s3");
            SetUnderTest.Add("s4");
            int startCount = SetUnderTest.Count();
            // verify does no harm
            SetUnderTest.RemoveWithLinq("sXXX");
            Assert.Equal(startCount, SetUnderTest.Count());
            // interior
            SetUnderTest.RemoveWithLinq("s3");
            Assert.Equal(startCount - 1, SetUnderTest.Count());
            Assert.False(SetUnderTest.Contains("s3"));
            // start
            SetUnderTest.RemoveWithLinq("s1");
            Assert.Equal(startCount - 2, SetUnderTest.Count());
            Assert.False(SetUnderTest.Contains("s1"));
            // end
            SetUnderTest.RemoveWithLinq("s4");
            Assert.Equal(startCount - 3, SetUnderTest.Count());
            Assert.False(SetUnderTest.Contains("s4"));
        }

        [Fact]
        public void Example_StringSet_TestAConversion()
        {
            StringSetExample aSet = new StringSetExample();
            aSet.Add("dog");
            aSet.Add("cat");
            ///aSet.Add("sheep");
            //// set up the mock
            Mock<IStringConverter> translatorMock = new Mock<IStringConverter>(/*MockBehavior.Strict*/);
            translatorMock.Setup(x => x.Translate("dog")).Returns("woof");
            translatorMock.Setup(x => x.Translate("cat")).Returns("meow");
            IStringConverter aTranslator = translatorMock.Object;

            //// run the converter
            StringSetExample aResultSet = aSet.Translate(aTranslator);
            //// verify the translator was called with the values we expected
            translatorMock.Verify(x => x.Translate("dog"), Times.Once());
            translatorMock.Verify(x => x.Translate("cat"), Times.Once());
            translatorMock.Verify(x => x.Translate("pig"), Times.Never());
            //// verify we got the expected translation
            Assert.True(aResultSet.Contains("woof"));
            Assert.True(aResultSet.Contains("meow"));
            Assert.Equal(2, aResultSet.Count());

        }

    }
}
