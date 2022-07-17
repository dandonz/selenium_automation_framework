using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumCore;
using Utilities;
using System;
using PageObjects;

namespace Tests
{
    public class LoginTest
    {
        IWebDriver driver;
        DriverManager driverManager;
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

        [Test]
        public void LoginSuccessWithValidCredential()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickLoginLink();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.EnterEmail("dand.ngoc@gmail.com");
            loginPage.EnterPassword("PassSec2019!");
            loginPage.ClickSubmit();
            string loggedUserName = homePage.GetLoggedUserName();
            Assert.AreEqual(loggedUserName, "LOG OUT");
            driverManager.QuitWebDriver();
        }
    }
}