using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_IT_Depot_Tests.PageObjects
{
    internal class BuyNowPage
    {
        IWebDriver? driver;
        public BuyNowPage(IWebDriver? driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath,Using = "(//a[@class='AddToCart']//child::button[contains(text(),'Buy')])[position()=1]")]
        private IWebElement? BuyNow {  get; set; }
        public ShopingCartPage BuyNowClick()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            fluentwait.Until(d => BuyNow);
            BuyNow?.Click();
            return new ShopingCartPage(driver);
        }
        [FindsBy(How = How.XPath,Using = "//a[@class='AddToWishList']")]
        private IWebElement? Wish { get; set; }
        public WishListPage WishListClick()
        {
            Wish?.Click();
            return new WishListPage(driver);
        }
    }
}
