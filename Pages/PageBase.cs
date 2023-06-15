using OpenQA.Selenium;
using TimeoutExtensions;
using OpenQA.Selenium.Support.UI;
using Hostinger.Drivers;

namespace Hostinger.Pages
{
    public abstract class PageBase
    {
        protected readonly SeleniumDriver Chrome;
        private WebDriverWait wait;

        public PageBase(SeleniumDriver chrome)
        {
            Chrome = chrome;
            wait = new WebDriverWait(chrome.Driver, TimeSpan.FromSeconds(10));
            Chrome.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        protected IWebElement GetElementByXPath(string xPath)
        {
            return Chrome.Driver.FindElementWithTimeout(By.XPath(xPath));
        }
        protected IWebElement GetElementByCSS(string CSS)
        {
            return Chrome.Driver.FindElementWithTimeout(By.CssSelector(CSS));
        }
        protected IWebElement GetElementByID(string id)
        {
            return Chrome.Driver.FindElementWithTimeout(By.Id(id));
        }
        protected IWebElement GetElementByText(string text)
        {
            return Chrome.Driver.FindElementWithTimeout(By.XPath(string.Format("//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{0}')]", text)));
        }
    }
}
