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
    public class NavigationBarTest
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
        public void NavigateToSchedulePage()
        {
            extentTest = null;
            extentTest = extentReports.CreateTest("T001").Info("Test Navigation Bar - Navigate to Schedule page");

            NavigationBar navigationBar = new NavigationBar(driver);
            navigationBar.ClickLoginLink();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("dand.ngoc@gmail.com", "PassSec2019!");

            System.Threading.Thread.Sleep(2000);

            navigationBar.ClickScheduleLink();

            extentTest.Log(Status.Info, "Click Schedule link on the Navigation Bar");

            System.Threading.Thread.Sleep(3000);

            //Get the H1 tag in SchedulePage
            SchedulePage schedulePage = new SchedulePage(driver);
            string title = schedulePage.getPageTile();
            Assert.AreEqual(title, "Cleaning Schedule");

            extentTest.Log(Status.Info, "Passed the page tile verification");

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
            //extentReports.Flush();
        }
    }
}
