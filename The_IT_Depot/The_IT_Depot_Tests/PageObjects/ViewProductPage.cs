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
    internal class ViewProductPage
    {
        IWebDriver? driver;
        public ViewProductPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id,Using = "search_sort_dropdown")]
        private IWebElement? GetSortBy {  get; set; }
        public void SortByClick()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            fluentwait.Until(d => GetSortBy);
            GetSortBy?.Click();

        }
       IWebElement ? ChooseSortItem(string choose)
        {
            return driver?.FindElement(By.XPath("//option[@value='"+choose+"']"));
        }
        public string ? ChooseText(string choose)
        {
            return ChooseSortItem(choose)?.Text;
        }
        public void ChooseItemClick(string choose)
        {
            ChooseSortItem(choose)?.Click();
        }
        [FindsBy(How = How.XPath,Using = "(//input[@name='subcategory_filter[]'])[position()=5]")]
        private IWebElement? Category { get; set; }
        public void CategoryClick()
        {
            Category?.Click();
        }
        IWebElement ? SelectProduct(string productNo)
        {
            return driver?.FindElement(By.XPath("(//div[@itemprop='name'])[position()="+productNo+"]"));
        }
       public BuyNowPage ClickBuyNow(string productNo)
        {
            SelectProduct(productNo)?.Click();
            return new BuyNowPage(driver);
        }

    }
}
