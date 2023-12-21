using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_IT_Depot_Tests.PageObjects
{
    internal class CheckOutPage
    {
        IWebDriver? driver;
        public CheckOutPage(IWebDriver driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath,Using = "(//input[@id='uname'])[1]")]
        private IWebElement? InputUnameText {  get; set; }
            
        
        public void TypeInputUser(string Uname)
        {
            InputUnameText?.SendKeys(Uname);
        }
        [FindsBy(How = How.XPath, Using = "(//input[@id='emailid'])[position()=1]")]
        private IWebElement?InputEmailText { get; set; }
        
        public void TypeInputEmail(string email)
        {
            InputEmailText?.SendKeys(email);
        }

        [FindsBy(How = How.XPath,Using = "(//input[@id='mobileno'])[position()=1]")]
        private IWebElement? InputMobileText { get; set; }
            
        public void TypeInputMobile(string mobile)
        {
            InputMobileText?.SendKeys(mobile);
        }
       [FindsBy(How = How.XPath,Using = "(//input[@id='passward'])[position()=1]")]
       private IWebElement?InputPasswordText { get; set; }
           
        public void TypeInputPassword(string password)
        {
            InputPasswordText?.SendKeys(password);
        }
        [FindsBy(How = How.XPath,Using = "(//input[@id='cpassward'])[position()=1]")]
        private IWebElement? InputConfirmPassword { get; set; }
        public void TypeConfirmPassword(string confirmPassword)
        {
            InputConfirmPassword?.SendKeys(confirmPassword);
        }
        [FindsBy(How = How.XPath,Using = "//button[text()='Sign Up']")]
        private IWebElement? SignUpButton {  get; set; }
        public void SignUpButtonClickz()
        {
            SignUpButton?.Click();
        }
        
    }
}
