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
    /// Page Object Pattern - Methods representing search results
    /// </summary>
    class PoPExampleSearchResultPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public PoPExampleSearchResultPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        internal PoPExampleSearchResultPage WaitForLinkText(string desiredLinkText, bool exact)
        {
            if (exact)
            {
                wait.Until(d => d.FindElement(By.LinkText(desiredLinkText)));
            } else
            {
                wait.Until(d => d.FindElement(By.PartialLinkText(desiredLinkText)));
            }
            return this; 
        }

        internal string Title()
        {
            return driver.Title;
        }

        internal PoPExampleTargetPage GoToPageLinkText(string desiredLinkText, bool exact)
        {
            if (exact)
            {
                IWebElement link = wait.Until(d => d.FindElement(By.LinkText(desiredLinkText)));
                link.Click();
            }
            else
            {
                IWebElement link = wait.Until(d => d.FindElement(By.PartialLinkText(desiredLinkText)));
                link.Click();
            }
            return new PoPExampleTargetPage(driver, wait);
        }


    }
}
