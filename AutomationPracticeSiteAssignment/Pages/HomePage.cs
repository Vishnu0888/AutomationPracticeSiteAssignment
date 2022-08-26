using AutomationPracticeSiteAssignment.Base;
using OpenQA.Selenium;

using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;


namespace AutomationPracticeSiteAssignment.Pages
{
    public class HomePage:BaseClass
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How =How.XPath,Using = "(//img[@alt='Faded Short Sleeve T-shirts'])[1]")]
        private IWebElement product1;

        [FindsBy(How =How.XPath,Using = "(//div[@class='product-image-container']/descendant::img[@title='Printed Dress'])[1]")]
        private IWebElement product2;

        [FindsBy(How =How.Id,Using = "product-container")]
        private IWebElement ElementForscroll;

        [FindsBy(How =How.XPath,Using = "(//div[@class='product-container']/descendant::a[@class='quick-view'])[1]")]
        private IWebElement quickviewprod1;

        [FindsBy(How = How.XPath, Using = "//p[@id='add_to_cart']/button/span")]
        private IWebElement AddtoCartprod1;

        [FindsBy(How =How.XPath,Using = "(//a[@data-id-product='3'])[1]")]
        private IWebElement Addtocartprod2;

        

        [FindsBy(How =How.XPath,Using = "//div[@class='button-container']/a[@data-id-product='1']/span")]
        private IWebElement addtocartbtn;

        [FindsBy(How =How.XPath,Using = "//div[@class='layer_cart_cart col-xs-12 col-md-6']/descendant::span[@title='Continue shopping']")]
        private IWebElement Continuebtn;

        [FindsBy(How =How.XPath,Using = "//a[@title='Home']")]
        private IWebElement homebtn;

        [FindsBy(How =How.CssSelector,Using = "a[title='View my shopping cart']")]
        private IWebElement shoppingCart;

        [FindsBy(How =How.XPath,Using = "//tr[@id='product_1_1_0_739094']/td[@class='cart_unit']/span/span")]
        public IWebElement item1incart;

        [FindsBy(How =How.XPath,Using = "//tr[@id='product_3_13_0_739094']/td[@class='cart_unit']/span/span")]
        public IWebElement item2incart;


      




        public IWebElement getProduct1()
        {
            return product1;
        }

        public QuickViewPage getQuickviewProd1()
        {
            quickviewprod1.Click();
            return new QuickViewPage(driver);
        }
       
        public IWebElement getAddtoCartprod1()
        {
            return AddtoCartprod1;
        }

        public IWebElement getAddTocartBtn()
        {
            return addtocartbtn;
        }

        public IWebElement getcontinueBtn()
        {
            return Continuebtn;
        }

       public IWebElement getHomebtn()
        {
            return homebtn;
        }

        public IWebElement getProduct2()
        {
            return product2;
        }


        public IWebElement getaddtocartProduct2()
        {
            return Addtocartprod2;
        }

        public IWebElement getShoopingcart()
        {
            return shoppingCart;
        }


      




    }
}
