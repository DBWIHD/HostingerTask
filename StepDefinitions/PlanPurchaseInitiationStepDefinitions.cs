using Hostinger.Drivers;
using Hostinger.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Hostinger.StepDefinitions
{
    [Binding]
    public class PlanPurchaseInitiationStepDefinitions
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        Main Main;
        CheckOut CheckOut;
        public PlanPurchaseInitiationStepDefinitions(SeleniumDriver chrome)
        {
            driver = chrome.Driver;
            CheckOut = new CheckOut(chrome);
            Main = new Main(chrome);
        }

        [Given(@"user is on hostinger page")]
        public void GivenUserIsOnHostingerPage()
        {
            driver.Url = "https://www.hostinger.com/";
            Main.ClickAcceptAllCookiesButton();
        }

        [Given(@"user adds hosting plan to a cart ""([^""]*)""")]
        public void GivenUserAddsHostingPlanToACart(int type)
        {
            Main.ClickClaimDealButton();
            Thread.Sleep(4000);
            Main.ClickAddToCartButton(type);
        }

        [Given(@"user select period ""([^""]*)""")]
        public void GivenUserSelectPeriod(int period)
        {
            Thread.Sleep(5000);
            CheckOut.SelectPeriodDisplayed(period);
            CheckOut.ClickSelectPeriod(period);
            Assert.That(CheckOut.PricePerMonthToInt(period) * CheckOut.PeriodToInt(period) == CheckOut.PeriodPriceToInt());
        }
        [When(@"user selects payment method ""([^""]*)""")]
        public void WhenUserSelectsPaymentMethod(int payment)
        {
            CheckOut.ClickSelectPayment(payment);
        }

        [Then(@"displayed information is correct")]
        public void ThenDisplayedInformationIsCorrect()
        {
            CheckOut.PaymentOverviewDisplayed();
        }
    }
 }