using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;


namespace AutomationPracticeSiteAssignment.Base
{
    public class BaseClass { 
    private IWebDriver driver;
    String browsername = ConfigurationManager.AppSettings["Browser"];
    String urlname = ConfigurationManager.AppSettings["URL"];

    ExtentReports extent;
    ExtentTest test;

        public IWebDriver getDriver()
    {
        return driver;
    }

        [OneTimeSetUp]
    public void initialize()
        {
            extent = new ExtentReports();
            string path = @"C:\Users\vishn\source\repos\AutomationPracticeSiteAssignment\AutomationPracticeSiteAssignment\index.html";
            ExtentHtmlReporter html = new ExtentHtmlReporter(path);
            extent.AttachReporter(html);
            extent.AddSystemInfo("Environment", "Pre-production");
            extent.AddSystemInfo("Hostname", "Localhost");
            extent.AddSystemInfo("Tester", "Vishnu");
        }

    [SetUp]
    public void setup()
    {
         test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
         getBroswer(browsername);
        getDriver().Url = urlname;
        getDriver().Manage().Window.Maximize();
        getDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        

    }
        [OneTimeTearDown]
        public void Terminate()
        {
            TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == TestStatus.Failed)
            {
                test.Fail("Method with name " + TestContext.CurrentContext.Test.Name + " is failed");
            }
            else
            {
                test.Pass("Test is Passed");
            }
            extent.Flush();
            driver.Close();
        }

        public IWebDriver getBroswer(string selectbrowser)
    {
        if (selectbrowser == browsername)
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            return driver = new ChromeDriver();

        }
        else if (selectbrowser == browsername)
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            return driver = new FirefoxDriver();
        }
        else
            return driver = new InternetExplorerDriver();

    }


    public void ScrollToanelement(IWebDriver driver, IWebElement element)
    {
        Actions action = new Actions(driver);
        action.MoveToElement(element).Build().Perform();
    }

     

        public void Scrollnew()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,400)");
        }
        public static void WindowScrollnew(IWebDriver driver,IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
        }


        public void WaitForElementDisplay(IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }



       public void selectValueFromDropdown(IWebDriver driver,IWebElement element,string selvalue)
        {
            SelectElement drop = new SelectElement(element);
            drop.SelectByValue(selvalue);
            
        }
        public string getSelectedOptionFromDropdown(IWebDriver driver, IWebElement element)
        {
            SelectElement drop = new SelectElement(element);
           IWebElement selectediwebelemnet= drop.SelectedOption;
           return selectediwebelemnet.Text;

        }



    }
}
