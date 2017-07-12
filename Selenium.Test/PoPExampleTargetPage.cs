using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium.Test
{
    internal class PoPExampleTargetPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

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