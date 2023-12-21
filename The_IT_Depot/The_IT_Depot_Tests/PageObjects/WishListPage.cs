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
    internal class WishListPage
    {
        IWebDriver? driver;
        public WishListPage(IWebDriver? driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath,Using = "//a[text()='×']")]
        private IWebElement? CloseWish { get; set; }
        public void WishListCloseClick()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            fluentwait.Until(d => CloseWish);
            CloseWish.Click();
        }
        
    }
}
