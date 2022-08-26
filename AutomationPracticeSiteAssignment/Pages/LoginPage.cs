using AutomationPracticeSiteAssignment.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeSiteAssignment.Pages
{
    public class LoginPage : BaseClass
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//a[@class='login']")]
        public IWebElement signinLink;

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        public IWebElement username;

        [FindsBy(How = How.XPath, Using = "//input[@id='passwd']")]
        public IWebElement password;

        [FindsBy(How = How.CssSelector, Using = "button[id ='SubmitLogin']")]
        public IWebElement subbtn;

        public HomePage getmeLoggedIN()
        {
            signinLink.Click();
            username.SendKeys("vishnutest@gmail.com");
            password.SendKeys("FujitsuTest");
            subbtn.Click();
            return new HomePage(driver);

        }

    }
}
