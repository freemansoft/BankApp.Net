using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Exercises.BDD.Test
{
    [Binding]
    public class HelloWorldExampleExampleSteps
    {
        [Given(@"I meet a person I wish to greet")]
        public void GivenIMeetAPersonIWishToGreet()
        {
            ScenarioContext.Current.Add("POI", new HelloWorldExample());
        }
        
        [Given(@"I know their name is ""(.*)""")]
        public void GivenIKnowTheirNameIs(string p0)
        {
            HelloWorldExample testObject = ScenarioContext.Current.Get<HelloWorldExample>("POI");
            testObject.seContactName(p0);
            ScenarioContext.Current.Add("ContactName", p0);
        }

        [When(@"I greet them")]
        public void WhenIGreetThem()
        {
            HelloWorldExample testObject = ScenarioContext.Current.Get<HelloWorldExample>("POI");
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
