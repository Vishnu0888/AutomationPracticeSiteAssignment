using AutomationPracticeSiteAssignment.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeSiteAssignment.Pages
{
    public class AccountProfilePage: BaseClass
    {
        private IWebDriver driver;

        public AccountProfilePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How =How.CssSelector,Using = "li a[title ='Orders']")]
        private IWebElement orderDetailsLink;



        public OrderHistoryPage ClickOrderDeatilsTab()
        {
            orderDetailsLink.Click();
            return new OrderHistoryPage(driver);
        }

    }
}
