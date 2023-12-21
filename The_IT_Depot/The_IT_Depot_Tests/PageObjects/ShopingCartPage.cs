using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_IT_Depot_Tests.PageObjects
{
    internal class ShopingCartPage
    {
        IWebDriver? driver;
        public ShopingCartPage(IWebDriver? driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            

        }
        public void QuantityChange(string qty)
        {
            IWebElement? QtyElement = driver.FindElement(By.XPath("(//div[@class='px-1']//child::input[@type='number'])[position()=1]"));
            Actions Qty = new Actions(driver);
            Qty.MoveToElement(QtyElement).Build().Perform();
            QtyElement.Clear();
            QtyElement.SendKeys(qty);
        }
        [FindsBy(How = How.XPath,Using = "//button[@type='submit' and text()='CHECKOUT ']")]
        private IWebElement? GetCheckout { get; set; }
        public CheckOutPage CheckoUtClick()
        {
            GetCheckout?.Click();
            return new CheckOutPage(driver);
        }
    }
}
