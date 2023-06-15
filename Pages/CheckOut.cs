using Hostinger.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Hostinger.Pages
{
    public static class CheckOutItems
    {
        //1 - 1 month, 2 - 12 months, 3 - 24 month, 4 - 48 months
        public static string SelectPeriod(int period) => $"(//*[@id='hcart-cart-period-selector'])[{period}]";
        //1 - credit card, 2 - paypal, 3 - google pay, 4 - alipay, 5 - coingate
        public static string SelectPayment(int payment) => $"(//*[contains(@id,'hcart-payment-method-select-')])[{payment}]";
        public static string PricePerMonth(int period) => $"(//*[@class='header-currency cart-period__main-price'])[{period}]";
        public static readonly string PlanNameAndPeriod = "((//*[contains(@class,'plan-info__plan-name')])[2]";
        public static readonly string PeriodPrice = "//*[@class='h-my-0']";
        public static readonly string PaymentOverview = "payment-overview";
        public static string Period(int period) => $"(//*[@class='up-body cart-period__period'])[{period}]";
    }

    public class CheckOut : PageBase
    {

        public CheckOut(SeleniumDriver chrome) : base(chrome)
        {
        }

        public void ClickSelectPeriod(int period)
        {
            WebDriverWait wait = new WebDriverWait(Chrome.Driver, TimeSpan.FromSeconds(5));
            IWebElement selectPeriod = wait.Until(ExpectedConditions.ElementToBeClickable(GetElementByXPath(CheckOutItems.SelectPeriod(period))));
            selectPeriod.Click();
        }   
        public bool SelectPeriodDisplayed(int period) => GetElementByXPath(CheckOutItems.SelectPeriod(period)).Displayed;
        public bool PaymentOverviewDisplayed() => GetElementByID(CheckOutItems.PaymentOverview).Displayed;
        public void ClickSelectPayment(int payment) => GetElementByXPath(CheckOutItems.SelectPayment(payment)).Click();
        public double PricePerMonthToInt(int period)
        {
            return Convert.ToDouble((GetElementByXPath(CheckOutItems.PricePerMonth(period)).Text).Substring(1));
        }
        public double PeriodPriceToInt()
        {
            return Convert.ToDouble((GetElementByXPath(CheckOutItems.PeriodPrice).Text).Substring(1));
        }
        public int PeriodToInt(int period)
        {
            string periodTitle = GetElementByXPath(CheckOutItems.Period(period)).Text;
            return Convert.ToInt32(periodTitle.Substring(0, periodTitle.IndexOf(' ')));
        }

    }
}
