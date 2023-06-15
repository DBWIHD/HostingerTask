using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Hostinger.Drivers
{
    public class SeleniumDriver
    {
        public IWebDriver Driver;
        public SeleniumDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("headless");
            options.AddArguments("window-size=1920,1080");
            options.AddArguments("no-sandbox");
            //options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(options);
        }
    }
}
