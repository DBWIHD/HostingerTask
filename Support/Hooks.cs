using OpenQA.Selenium;
using Hostinger.Drivers;

namespace Hostinger.Support
{
    [Binding]
    public sealed class Hooks
    {
        private IWebDriver driver;
        public Hooks(SeleniumDriver chrome)
        {
            driver = chrome.Driver;

        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();

        }
    }
}