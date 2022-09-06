using AutomationPracticeSiteAssignment.Base;
using AutomationPracticeSiteAssignment.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace AutomationPracticeSiteAssignment
{
    //[Parallelizable(ParallelScope.Children)]
    public class Tests : BaseClass
    {
     [Test,Order(1)]
        public void AddProduct()
        {
            try
            {
                LoginPage lg = new LoginPage(getDriver());
                HomePage hm = lg.getmeLoggedIN();
                hm.getHomebtn().Click();
                Scrollnew();
                ScrollToanelement(getDriver(), hm.getProduct1());
                hm.getAddTocartBtn().Click();
                hm.getcontinueBtn().Click();
                ScrollToanelement(getDriver(), hm.getProduct2());
                hm.getaddtocartProduct2().Click();
                hm.getcontinueBtn().Click();
                hm.getShoopingcart().Click();
                string totalcost = getDriver().FindElement(By.XPath("//span[@id='total_price']")).Text;
                string[] cost = totalcost.Split("$");
                string originalcost = cost[1];
                Assert.AreEqual(originalcost, "44.51");

            }
            catch(Exception e)
            {
                test.Fail(e.StackTrace);
            }
            

        }
        [Test,Order(2)]
        public void ProceedToCheckOut()
        {
            try
            {
                LoginPage lg = new LoginPage(getDriver());
                HomePage hm = lg.getmeLoggedIN();
                hm.getHomebtn().Click();
                Scrollnew();
                ScrollToanelement(getDriver(), hm.getProduct1());
                hm.getAddTocartBtn().Click();
                hm.getcontinueBtn().Click();
                ScrollToanelement(getDriver(), hm.getProduct2());
                hm.getaddtocartProduct2().Click();
                hm.getcontinueBtn().Click();
                hm.getShoopingcart().Click();
                //Checking Out
                getDriver().FindElement(By.XPath("//p[@class='cart_navigation clearfix']/a[@title='Proceed to checkout']")).Click();
                getDriver().FindElement(By.CssSelector("button[name='processAddress']")).Click();

                Scrollnew();
                IWebElement chkbox = getDriver().FindElement(By.CssSelector("div[id='uniform-cgv'] span input"));
                if (chkbox.Selected == false)
                {
                    chkbox.Click();
                }
                getDriver().FindElement(By.XPath("//button[@name='processCarrier']")).Click();
                getDriver().FindElement(By.XPath("//a[@title='Pay by bank wire']")).Click();
                getDriver().FindElement(By.XPath("//span[text()='I confirm my order']/parent::button")).Click();

                string successmsg = getDriver().FindElement(By.XPath("//strong[text()='Your order on My Store is complete.']")).Text;
                Assert.IsTrue(successmsg.Contains("complete"));
            }
            catch(Exception e)
            {
                test.Fail(e.StackTrace);
            }
           
                
        }


        [Test,Order(3),Category("Smoke")]
        public void ValidateCost()
        {
            try
            {
                LoginPage lg = new LoginPage(getDriver());
                HomePage hm = lg.getmeLoggedIN();
                hm.getHomebtn().Click();
                Scrollnew();
                ScrollToanelement(getDriver(), hm.getProduct1());
                hm.getAddTocartBtn().Click();
                hm.getcontinueBtn().Click();
                ScrollToanelement(getDriver(), hm.getProduct2());
                hm.getaddtocartProduct2().Click();
                hm.getcontinueBtn().Click();
                hm.getShoopingcart().Click();
                //Validating Price of the product selected
                CartPage cp = new CartPage(getDriver());
                double shippingprice = cp.getShiipingcost();
                double totalpice = cp.getTotalfinalcost();
                double pricetocustomer = cp.getFinalCostToCustomer();
                Assert.AreEqual(shippingprice + totalpice, pricetocustomer);

            }
            catch(Exception e)
            {
                test.Fail(e.StackTrace);
            }
            



        }
        [Test,Order(4),Category("Regression")]
        public void Test_QuickViewAddProduct()
        {
            try
            {
                LoginPage lg = new LoginPage(getDriver());
                HomePage hm = lg.getmeLoggedIN();
                hm.getHomebtn().Click();
                Scrollnew();
                ScrollToanelement(getDriver(), hm.getProduct1());
                QuickViewPage qv = hm.getQuickviewProd1();
                getDriver().SwitchTo().Frame(1);
                System.Threading.Thread.Sleep(20000);
                selectValueFromDropdown(getDriver(), qv.getDropdown(), "3");
                string titlesize = getSelectedOptionFromDropdown(getDriver(), qv.getDropdown());
                Console.WriteLine(titlesize);
                qv.getAddtoCartprod1().Click();
                CartPage cp = qv.ClickOnCheckout();
                Scrollnew();

                Assert.AreEqual(titlesize, cp.getSizeText().Trim());
            }
            catch(Exception e)
            {
                test.Fail(e.StackTrace);
            }

        }


        [Test,Order(5)]
        public void Test_ValidateOrderHistory()
        {
            try 
            {
                String messagepost = "This is the test message by Vishnu";
                LoginPage lg = new LoginPage(getDriver());
                HomePage hm = lg.getmeLoggedIN();
                AccountProfilePage Ap = hm.getUsrnameTitleClick();
                OrderHistoryPage ohp = Ap.ClickOrderDeatilsTab();
                ohp.CheckDateAndSelectItem();
                ScrollToanelement(getDriver(), ohp.getMessageSubmitBtn());
                ohp.getmessageArea().SendKeys(messagepost);
                ohp.getMessageSubmitBtn().Click();
                WaitForElementDisplay(getDriver(), ohp.getSuccessmsg());
                Assert.AreEqual(messagepost, ohp.getPostedMsg());
            }
            catch(Exception e)
            {
                test.Fail(e.StackTrace);
            }
                

        }


    }
}