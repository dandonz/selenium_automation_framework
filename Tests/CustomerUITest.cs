using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumCore;
using Utilities;
using PageObjects;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Tests
{
    [TestFixture]
    public class CustomerTest
    {
        IWebDriver driver;
        DriverManager driverManager;
        static ExtentTest extentTest;
        static ExtentReports extentReports;

        [SetUp]
        public void Setup()
        {
            //Initialize driver
            driverManager = DriverManagerFactory.GetDriverManager(BROWSER_TYPE.CHROME);
            driver = driverManager.GetWebDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Navigate().GoToUrl("https://danyspace.com/");
            System.Threading.Thread.Sleep(1000);
        }

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extentReports = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter("/Users/0s/Downloads/" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extentReports.AttachReporter(htmlreporter);
        }

        [Test]
        public void ListAllCustomersWhenAccessingCustomerPage()
        {
            extentTest = null;
            extentTest = extentReports.CreateTest("T001").Info("Click on Customer link test");

            //No need login
            HomePage homePage = new HomePage(driver);
            homePage.ClickCustomersLink();
            extentTest.Log(Status.Info, "Click Customer link on Home page");

            System.Threading.Thread.Sleep(3000);
            CustomerPage customerPage = new CustomerPage(driver);
            string textvalue = customerPage.GetNumberOfCustomersText();
            Console.WriteLine(textvalue);
            Assert.IsTrue(textvalue.Contains("34"));

            extentTest.Log(Status.Pass, "Test Pass");
        }


        [TearDown]
        public void CloseBrowser()
        {
            driverManager.QuitWebDriver();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extentReports.Flush();
        }
    }
}
