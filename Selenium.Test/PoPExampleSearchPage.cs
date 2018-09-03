using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Test
{
    /// <summary>
    /// Example:
    /// Page Object Pattern - Methods representing search page
    /// </summary>
    class PoPExampleSearchPage
    {
        public static string Google = "https://www.google.com";
        public static string Bing = "https://www.bing.com";

        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly string searchEngine;

        public PoPExampleSearchPage(IWebDriver driver, WebDriverWait wait, string searchEngine)
        {
            this.driver = driver;
            this.wait = wait;
            this.searchEngine = searchEngine;
        }

        internal PoPExampleSearchResultPage SearchFor(string searchString)
        {
            driver.Navigate().GoToUrl(searchEngine);
            IWebElement queryField = driver.FindElement(By.Name("q"));
            queryField.SendKeys(searchString);
            queryField.Submit();
            return new PoPExampleSearchResultPage(driver, wait) ;
        }
    }
}
