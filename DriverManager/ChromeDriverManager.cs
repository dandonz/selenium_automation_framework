using OpenQA.Selenium.Chrome;
using WebDriverManager.Helpers;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumCore
{
    public class ChromeDriverManager : DriverManager
    {
        protected override void CreateWebDriver()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            //The "headless" mode should be configured in testcase or configuration file. 
            //chromeOptions.AddArgument("--headless");
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), "Latest", Architecture.Auto);
            this.driver = new ChromeDriver(chromeOptions);
        }
    }
}