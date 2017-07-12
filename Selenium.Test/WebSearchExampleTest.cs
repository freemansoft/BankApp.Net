using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Test
{
    [TestClass]
    public class WebSearchExampleTest
    {
 
        private IWebDriver driver;
        private WebDriverWait wait;

        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            //driver = new ChromeDriver();
            // https://code.google.com/p/selenium/wiki/InternetExplorerDriver#Required_Configuration
            var options = new InternetExplorerOptions
            {
                IgnoreZoomLevel = true
            };
            //driver = new InternetExplorerDriver(options);
            //driver = new InternetExplorerDriver();
            //driver = new ChromeDriver();
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
        //

        [TestMethod]
        public void Example_SearchForFreemanSoft()
        {
            string desiredLinkText = "FreemanSoft Inc";
            driver.Navigate().GoToUrl("https://www.google.com");
            IWebElement queryField = driver.FindElement(By.Name("q"));
            queryField.SendKeys("freemansoft");
            queryField.Submit();
            // wait until a link for the search term shows up before doing anything else
            Assert.IsNotNull(wait.Until(d => d.FindElement(By.LinkText(desiredLinkText))));
            // google puts search term in title bar after search
            StringAssert.Contains(driver.Title, "freemansoft");
            // find the link again and click on it to go to the home page
            IWebElement link = wait.Until(d => d.FindElement(By.LinkText(desiredLinkText)));
            link.Click();
            StringAssert.Contains(driver.Title, "FreemanSoft");
        }

        [TestMethod]
        public void Example_SearchForAmazon()
        {
            string desiredLinkText = "Amazon.com® Official Site";
            driver.Navigate().GoToUrl("https://www.google.com");
            IWebElement queryField = driver.FindElement(By.Name("q"));
            queryField.SendKeys("amazon");
            queryField.Submit();
            // wait until the field we are interested in shows up - otherwise fail test
            Assert.IsNotNull(wait.Until(d => d.FindElement(By.PartialLinkText(desiredLinkText))));
            // now actually grab the link to click
            IWebElement link = driver.FindElement(By.PartialLinkText(desiredLinkText));
            link.Click();
            Thread.Sleep(5000);

        }
    }
}
