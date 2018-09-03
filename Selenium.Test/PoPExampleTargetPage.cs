using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Test
{
    /// <summary>
    /// Example:
    /// Page Object Pattern - Methods representing target page after clicking on search results
    /// </summary>
    internal class PoPExampleTargetPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public PoPExampleTargetPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        internal string Title()
        {
            return driver.Title;
        }

    }
}