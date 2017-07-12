using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Test
{
    [TestClass]
    public class PoPExampleTest
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
        public void Example_SearchForAndGoToFreemanSoft()
        {
            string desiredSearchString = "freemansoft";
            string desiredLinkText = "FreemanSoft Inc";
            PoPExampleSearchResultPage Result = new PoPExampleSearchPage(driver, wait, PoPExampleSearchPage.Google).SearchFor(desiredSearchString);
            StringAssert.Contains(Result.WaitForLinkText(desiredLinkText, true).Title(), desiredSearchString);
            PoPExampleTargetPage Target = Result.GoToPageLinkText(desiredLinkText, true);
            StringAssert.Contains(Target.Title(), "FreemanSoft");
        }

        [TestMethod]
        public void Example_SearchForAndGoToAmazon()
        {
            string desiredSearchString = "amazon";
            string desiredLinkText = "Amazon.com";
            PoPExampleSearchResultPage Result = new PoPExampleSearchPage(driver, wait, PoPExampleSearchPage.Google).SearchFor(desiredSearchString);
            StringAssert.Contains(Result.WaitForLinkText(desiredLinkText, false).Title(), desiredSearchString);
            PoPExampleTargetPage Target = Result.GoToPageLinkText(desiredLinkText, false);
            StringAssert.Contains(Target.Title(), "Amazon");
        }
    }
}
