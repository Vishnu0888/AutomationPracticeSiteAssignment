using AutomationPracticeSiteAssignment.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeSiteAssignment.Pages
{
    public class QuickViewPage : BaseClass
    {
        public IWebDriver driver;

        public QuickViewPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//p[@id='add_to_cart']/button")]
        private IWebElement AddtoCartprod1btn;

        [FindsBy(How = How.XPath, Using = "//span[@id='our_price_display']")]
        public IWebElement displaycost;

        [FindsBy(How =How.XPath,Using = "//iframe[@id='fancybox-frame1661687137562']")]
        public IWebElement frameid;

        [FindsBy(How =How.XPath,Using = "//iframe[@id='fancybox-frame1661687137562']")]
        public IWebElement outerframe;

        [FindsBy(How =How.XPath,Using = "//select[@id='group_1']")]
        private IWebElement sizedropdown;

        [FindsBy(How =How.XPath,Using = "//a[@title='Proceed to checkout']")]
        private IWebElement checkoutbtn;


        public IWebElement getAddtoCartprod1()
        {
            return AddtoCartprod1btn;
        }

        public IWebElement getDropdown()
        {
            return sizedropdown;
        }

        public CartPage ClickOnCheckout()
        {
            checkoutbtn.Click();
            return new CartPage(driver);
        }


    }
}
