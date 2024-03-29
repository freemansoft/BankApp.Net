﻿using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Test
{
    /// <summary>
    /// Example Standalone Selenium search UI test
    /// <para></para>
    /// Simple Selenium test searching in google for a couple websites.
    /// Verfies results by clicking on link.
    /// No utility methods.  Have to edit code to switch between Chrome and IE
    /// <para></para>
    /// Test methods starting with "Example" were provided for the sessions.
    /// </summary>
    [TestClass]
    public class ExampleWebSearchTest
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
        public void Example_SearchForLinkedIn()
        {
            string desiredLinkText = "LinkedIn:";
            driver.Navigate().GoToUrl("https://www.google.com");
            IWebElement queryField = driver.FindElement(By.Name("q"));
            queryField.SendKeys("linkedin");
            queryField.Submit();
            // wait until a link for the search term shows up before doing anything else
            Assert.IsNotNull(wait.Until(d => d.FindElement(By.PartialLinkText(desiredLinkText))));
            // google puts search term in title bar after search
            StringAssert.Contains(driver.Title, "linkedin");
            // find the link again and click on it to go to the home page
            IWebElement link = wait.Until(d => d.FindElement(By.PartialLinkText(desiredLinkText)));
            link.Click();
            StringAssert.Contains(driver.Title, "LinkedIn");
        }

        [TestMethod]
        public void Example_SearchForAmazon()
        {
            // find a link - try to not used a sponsored ad because those change
            string desiredLinkText = "Amazon.com Official Site";
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
