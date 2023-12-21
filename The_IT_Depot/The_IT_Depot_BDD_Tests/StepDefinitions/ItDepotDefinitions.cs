using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Security.Authentication.ExtendedProtection;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using The_IT_Depot_BDD_Tests.Hooks;

namespace The_IT_Depot_BDD_Tests.StepDefinitions
{
    [Binding]
    public class ItDepotDefinitions : Corecodes
    {
        IWebDriver? driver = BeforeHooks.driver;
        [Given(@"User is in the ITDEPOT Homepage")]
        public void GivenUserIsInTheITDEPOTHomepage()
        {
            driver.Url = "https://www.theitdepot.com/";
            driver.Manage().Window.Maximize();
        }

        [When(@"User enter a product name '([^']*)' in the Search Box")]
        public void WhenUserEnterAProductNameInTheSearchBox(string productname)
        {
            IWebElement searchData = driver.FindElement(By.XPath("//input[@id='keywords']"));
            searchData.SendKeys(productname);
            searchData.SendKeys(Keys.Enter);
        }

        [Then(@"User redirect to the ViewProductPage")]
        public void ThenUserRedirectToTheViewProductPage()
        {
            Assert.That(driver.Url.Contains("mobile"));
        }

        [When(@"User Click on the sortBy box and click on the category '([^']*)'")]
        public void WhenUserClickOnTheSortByBoxAndClickOnTheCategory(string catagory)
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement selectclick = fluentwait.Until(d=>d.FindElement(By.Id("search_sort_dropdown")));
            selectclick.Click();
            //Thread.Sleep(3000);
            IWebElement choose = fluentwait.Until(ds => ds.FindElement(By.XPath("//option[@value='" + catagory + "']")));
            choose.Click();

        }

        [When(@"User Click on subCatagories '([^']*)'")]
        public void WhenUserClickOnSubCatagories(string sub)
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement subcatagory = fluentwait.Until(d => d.FindElement(By.XPath("(//input[@name='subcategory_filter[]'])[position()="+sub+"]")));
            subcatagory.Click();
        }

        [When(@"User click on the particularproduct '([^']*)'")]
        public void WhenUserClickOnTheParticularproduct(string productNo)
        {
            //div[@itemprop='name'])[position()="+productNo+"]
            DefaultWait < IWebDriver > fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement productSelect = fluentwait.Until(d => d.FindElement(By.XPath("(//div[@itemprop='name'])[position()=" + productNo + "]")));
            productSelect.Click();
        }

        [Then(@"User redirect to the BuyNowPage")]
        public void ThenUserRedirectToTheBuyNowPage()
        {
            IWebElement ele = driver.FindElement(By.XPath("//div[text()='Message us']"));
            Assert.That(ele.Text.Contains("Message"));
        }

        [When(@"User click on the BuyNow Button")]
        public void WhenUserClickOnTheBuyNowButton()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement buy = fluentwait.Until(x=>x.FindElement(By.XPath("(//a[@class='AddToCart']//child::button[contains(text(),'Buy')])[position()=1]")));
            buy.Click();
            //Thread.Sleep(3000);

        }

        [Then(@"User redirect to the ShoppingCartPage")]
        public void ThenUserRedirectToTheShoppingCartPage()
        {
            Assert.That(driver.Url.Contains("cart"));
        }

        [When(@"User click on the Quatity and enter quantity '([^']*)'")]
        public void WhenUserClickOnTheQuatityAndEnterQuantity(string qty)
        {
            //div[@class='px-1']//child::input[@type='number'])[position()=1]
            DefaultWait < IWebDriver > fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement Qty = fluentwait.Until(y=>y.FindElement(By.XPath("(//div[@class='px-1']//child::input[@type='number'])[position()=1]")));
            Qty.Clear();
            Qty.SendKeys(qty);
        }

        [When(@"User click on the Checkout Button")]
        public void WhenUserClickOnTheCheckoutButton()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement checkout = fluentwait.Until(s => s.FindElement(By.XPath("//button[@type='submit' and text()='CHECKOUT ']")));
            checkout.Click();
        }

        [Then(@"User Redirect to the checkoutpage")]
        public void ThenUserRedirectToTheCheckoutpage()
        {
            IWebElement checkout = driver.FindElement(By.XPath("//h5[text()='Checkout']"));

            Assert.That(checkout.Text.Contains("Checkout"));
        }

        [When(@"User Type Name in the input box '([^']*)'")]
        public void WhenUserTypeNameInTheInputBox(string Name)
        {
            IWebElement name = driver.FindElement(By.XPath("(//input[@id='uname'])[1]"));
            name.SendKeys(Name);
        }

        [When(@"User Type Email in the input box '([^']*)'")]
        public void WhenUserTypeEmailInTheInputBox(string Email)
        {
            IWebElement email = driver.FindElement(By.XPath("(//input[@id='emailid'])[1]"));
            email.SendKeys(Email);
        }

        [When(@"User Type Mobile Number in the input box '([^']*)'")]
        public void WhenUserTypeMobileNumberInTheInputBox(string Mobile)
        {
            IWebElement mobile = driver.FindElement(By.XPath("(//input[@id='mobileno'])[1]"));
            mobile.SendKeys(Mobile);
        }

        [When(@"User Type Password in the input box '([^']*)'")]
        public void WhenUserTypePasswordInTheInputBox(string Password)
        {
            IWebElement password = driver.FindElement(By.XPath("(//input[@id='passward'])[1]"));
            password.SendKeys(Password);
        }

        [When(@"User Type Confirm Password in the input box '([^']*)'")]
        public void WhenUserTypeConfirmPasswordInTheInputBox(string Cpassward)
        {
            IWebElement cpassword = driver.FindElement(By.XPath("(//input[@id='cpassward'])[1]"));
            cpassword.SendKeys(Cpassward);
        }

        [When(@"User click on the signup button")]
        public void WhenUserClickOnTheSignupButton()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement signUp = fluentwait.Until(s=>s.FindElement(By.XPath("//button[text()='Sign Up']")));
            signUp.Click();
            //Thread.Sleep(3000);
            
        }

        [Then(@"User Redirect to the checkout page")]
        public void ThenUserRedirectToTheCheckoutPage()
        {
            TakeScreenShot(driver);
            try
            {
                Assert.That(driver.Url.Contains("checkout"));
                LogTestResult("Search And Buy Product Test ","Pass");
                
            }
            catch(AssertionException ex)
            {
                LogTestResult("Search And Buy Product Test", "Fail", ex.Message);
                TakeScreenShot(driver);
            }
        }
        [When(@"User click on the WishList Button")]
        public void WhenUserClickOnTheWishListButton()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement wishlist = fluentwait.Until(x=>x.FindElement(By.XPath("//a[@class='AddToWishList']")));
            wishlist.Click();
            //Thread.Sleep(3000);
        }

        [Then(@"User redirect to the WishListPage")]
        public void ThenUserRedirectToTheWishListPage()
        {
            Assert.That(driver.Url.Contains("mywishlist"));
        }

        [When(@"User Click on the wishList Close Button")]
        public void WhenUserClickOnTheWishListCloseButton()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement closewish = fluentwait.Until(y=>y.FindElement(By.XPath("//a[text()='×']")));
            closewish.Click();
           // Thread.Sleep(3000);
            
        }

        [Then(@"User view the empty listpage")]
        public void ThenUserViewTheEmptyListpage()
        {
            TakeScreenShot(driver);
            IWebElement? emptyelement = driver.FindElement(By.XPath("//p[text()='Your Wishlist is Empty']"));
            try
            {


                Assert.That(emptyelement.Text.Equals("Your Wishlist is Empty"));
                LogTestResult("Search and WishListTest","Pass");
            }
            catch(AssertionException ex)
            {
                LogTestResult("Search and WishListTest", "Fail", ex.Message);
                TakeScreenShot(driver);
            }
        }

    }
}
