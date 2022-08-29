using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeSiteAssignment.Pages
{
    public class CartPage
    {

        public IWebDriver driver;
        
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How =How.XPath,Using = "//td[@id='total_product']")]
        private IWebElement totalcostelement;

        [FindsBy(How =How.XPath,Using = "//td[@id='total_shipping']")]
        private IWebElement shippingcostelement;


        [FindsBy(How =How.XPath,Using = "//td/span[@id='total_price']")]
        private IWebElement totalpricetoCustomerelement;

        [FindsBy(How =How.XPath,Using = "//td/small/a[text()='Color : Orange, Size : L']")]
        private IWebElement size;


        public double getTotalfinalcost()
        {
            string totalcost = totalcostelement.Text;
            string[] totalcost1 = totalcost.Split("$");
            string newtotalcost2 = totalcost1[1];
            double finaltotalcost = double.Parse(newtotalcost2);
            return finaltotalcost;
        }

        public double getShiipingcost()
        {
            string shippingcost = shippingcostelement.Text;
            string[] shippingcost1 = shippingcost.Split("$");
            string newshippingcost = shippingcost1[1];
            double finalshippingcost = double.Parse(newshippingcost);
            return finalshippingcost;
        }

        public double getFinalCostToCustomer()
        {
            string totalPrice = totalpricetoCustomerelement.Text;
            string[] newtotalprice = totalPrice.Split("$");
            string newtotalprice1 = newtotalprice[1];
            double finaltotalprice = double.Parse(newtotalprice1);
            return finaltotalprice;
        }

        
        public string getSizeText()
        {
            string sizeofitem=size.Text;
            string [] sizebreak=sizeofitem.Split(",");
            string finalsize = sizebreak[1];
            string[] complsize=sizebreak[1].Split(":");
            string mysize = complsize[1];
            return mysize;
        }

        




    }
}
