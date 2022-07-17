using OpenQA.Selenium.Firefox;
using WebDriverManager.Helpers;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumCore
{
    public class FirefoxDriverManager : DriverManager
    {
        protected override void CreateWebDriver()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            //The "headless" mode should be configured in testcase or configuration file. 
            //firefoxOptions.AddArgument("--headless");
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig(), "Latest", Architecture.Auto);
            this.driver = new FirefoxDriver(firefoxOptions);
        }
    }
}
