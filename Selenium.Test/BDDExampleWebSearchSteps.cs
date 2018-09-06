using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Selenium.Test
{
    /// <summary>
    /// Example Step functions for BDDExampleWebSearch.feature
    /// </summary>
    [Binding]
    public class BDDExampleWebSearchSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [BeforeScenario]
        public void BeforeScenario()
        {
            // IWebDriver driver = new ChromeDriver();
            IWebDriver driver = new ChromeDriver();

            // you protection mode must be the same for all zones and you need to be zoomed at 100% to use IE
            //IWebDriver driver = new InternetExplorerDriver();
            //IWebDriver driver = new InternetExplorerDriver("C:\\class\\SeleniumSearch - Partial Solution\\vs2010solution\\packages\\Selenium.WebDriver.IEDriver.2.46.0.0\\driver");
            ScenarioContext.Current.Set<IWebDriver>(driver, "driver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>("driver");
            driver.Quit();
        }

        [Given(@"I want to search with ""(.*)""")]
        public void GivenIWantToSearchWithGoogle(string p0)
        {
            IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>("driver");
            driver.Navigate().GoToUrl("https://www." + p0 + ".com");
        }


        /// <summary>
        /// Saves the last search term to be used in "Then" statements
        /// </summary>
        /// <param name="p0"></param>
        [When(@"When I search for ""(.*)""")]
        public void WhenWhenISearchFor(string p0)
        {
            ScenarioContext.Current.Set<string>(p0, "lastSearch");
            IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>("driver");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Name("q")));
            IWebElement queryField = driver.FindElement(By.Name("q"));
            queryField.SendKeys(p0);
            queryField.Submit();
            // wait until we get some link with FreemanSoft in it
            Assert.IsNotNull(wait.Until(d => d.FindElement(By.PartialLinkText(p0))));
        }

        /// <summary>
        /// Assumes "search term " refers to last search term
        /// </summary>
        [Then(@"My search term should be in the title bar")]
        public void MySearchTermShouldBeInTheTitleBar()
        {
            string lastSearch = ScenarioContext.Current.Get<string>("lastSearch");
            IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>("driver");
            string title = driver.Title;
            StringAssert.Contains(title, lastSearch);
        }
    }

}
