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
    internal class ITDepot_HomePage
    {
        IWebDriver? driver;
        public ITDepot_HomePage(IWebDriver? driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath,Using="//input[@id='keywords']")]
        private IWebElement? GetSearchBox {  get; set; }
        public void InputSearchBox(string searchitem)
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            fluentwait.Until(d => GetSearchBox);
            GetSearchBox?.SendKeys(searchitem);
          
        }
        public ViewProductPage ViewProduct()
        {
            GetSearchBox?.SendKeys(Keys.Enter);
            return new ViewProductPage(driver);
        }

    }
}
