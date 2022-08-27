using AutomationPracticeSiteAssignment.Base;
using AutomationPracticeSiteAssignment.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace AutomationPracticeSiteAssignment
{
    public class Tests : BaseClass
    {


        [Test]
        public void AddProduct()
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
        [Test]
        public void ProceedToCheckOut()
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


        [Test]
        public void ValidateCost()
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

    }
}