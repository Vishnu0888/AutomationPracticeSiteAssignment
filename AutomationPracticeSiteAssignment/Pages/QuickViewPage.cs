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


        [FindsBy(How = How.XPath, Using = "//p[@id='add_to_cart']/button/span")]
        private IWebElement AddtoCartprod1;

        [FindsBy(How = How.XPath, Using = "//span[@id='our_price_display']")]
        public IWebElement displaycost;

        [FindsBy(How =How.Id,Using = "fancybox-frame1661505793592")]
        public IWebElement frameid;

        public IWebElement getAddtoCartprod1()
        {
            return AddtoCartprod1;
        }


    }
}
