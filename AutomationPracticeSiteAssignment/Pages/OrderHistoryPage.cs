using AutomationPracticeSiteAssignment.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeSiteAssignment.Pages
{
    public class OrderHistoryPage: BaseClass
    {
        private IWebDriver driver;
        public OrderHistoryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How =How.XPath,Using = "//tr[@class='first_item ']/td[contains(text(),'08/29/2022')]")]
        private IWebElement firstelementdate;
        
        [FindsBy(How =How.XPath,Using = "//tr[@class='first_item ']/td[contains(text(),'08/29/2022')]/preceding-sibling::td/a")]
        private IWebElement FirstElementItemLink;

        [FindsBy(How =How.CssSelector,Using = "p[class='form-group'] textarea")]
        private IWebElement messagearea;

        [FindsBy(How =How.CssSelector,Using = "div[class='submit'] button")]
        private IWebElement submitbuttonformessage;

        [FindsBy(How =How.XPath,Using = "//p[contains(text(),'Message successfully sent')]")]
        private IWebElement successmsg;

        [FindsBy(How =How.XPath,Using = "//h3[text()='Messages']/following-sibling::div[@class='table_block']/table/tbody/tr/td[2]")]
        private IWebElement postedmsg;

        public void CheckDateAndSelectItem()
        {
            string datenew = firstelementdate.Text;
            
           if(datenew.Trim() == "08/29/2022")
            {
                FirstElementItemLink.Click();
            }
        }

        public IWebElement getmessageArea()
        {
            return messagearea;
        }

        public IWebElement getMessageSubmitBtn()
        {
            return submitbuttonformessage;
        }

        public IWebElement getSuccessmsg()
        {
            return successmsg;
        }

        public string getPostedMsg()
        {
            return postedmsg.Text;
        }



    }
}
