using Hostinger.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Hostinger.Pages
{
    public static class MainItems
    {
        //1 - Premium Web Hosting, 2 - Business Web Hosting, 3 - Cloud Startup
        public static string AddToCartButton(int type) => $"(//*[@class='h-carousel-card-wrapper']//button)[{type}]";
        public static readonly string AcceptAllCookiesButton = "//*[@data-click-id='hgr-cookie_consent-accept_all_btn']";
        public static readonly string ClaimDealButton = "//*[@data-click-id='hgr-header-cta-get_started']";
    }

    public class Main : PageBase
    {

        public Main(SeleniumDriver chrome) : base(chrome)
        {
        }

        public void ClickAddToCartButton(int type)
        {            
            var element = GetElementByXPath(MainItems.AddToCartButton(type));
            WebDriverWait wait = new WebDriverWait(Chrome.Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            Actions action = new Actions(Chrome.Driver);
            action.MoveToElement(element);
            action.Perform();
            element.Click();
        }
        public void ClickClaimDealButton() => GetElementByXPath(MainItems.ClaimDealButton).Click();
        public void ClickAcceptAllCookiesButton() => GetElementByXPath(MainItems.AcceptAllCookiesButton).Click();
    }
}
