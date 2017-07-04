using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BankLibrary.BDD.Test
{
    [Binding]
    public class HelloWorldSteps
    {
        [Given(@"I meet a person I wish to greet")]
        public void GivenIMeetAPersonIWishToGreet()
        {
            ScenarioContext.Current.Add("POI", new HelloWorld());
        }
        
        [Given(@"I know their name is ""(.*)""")]
        public void GivenIKnowTheirNameIs(string p0)
        {
            HelloWorld testObject = ScenarioContext.Current.Get<HelloWorld>("POI");
            testObject.seContactName(p0);
            ScenarioContext.Current.Add("ContactName", p0);
        }

        [When(@"I greet them")]
        public void WhenIGreetThem()
        {
            HelloWorld testObject = ScenarioContext.Current.Get<HelloWorld>("POI");
            String result = testObject.sayHello();
            ScenarioContext.Current.Add("FullGreetingString", result);
        }
        
        [Then(@"The result should be ""(.*)""")]
        public void ThenTheResultShouldBe(string p0)
        {
            String result = ScenarioContext.Current.Get<String>("FullGreetingString");
            Assert.AreEqual<String>("Hello " + ScenarioContext.Current.Get<String>("ContactName"), result);
        }
    }
}
