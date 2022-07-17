using OpenQA.Selenium;

namespace SeleniumCore
{
    public abstract class DriverManager
    {
        protected IWebDriver driver;
        protected abstract void CreateWebDriver();
        public IWebDriver GetWebDriver()
        {
            if(null == driver)
            {
                CreateWebDriver();
            }
            return driver; 
        }
        public void QuitWebDriver()
        {
            if(null != driver)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }


    /// <summary>
    /// This class is used to select a DriverManager such as Chrome, Firefox, Safari... based on type
    /// "type" parameter is setup in TestCase where it wants to run the test on a specific browser
    /// </summary>
    public static class DriverManagerFactory
    {
        public static DriverManager GetDriverManager(string type)
        {
            DriverManager driverManager;
            switch (type)
            {
                case "CHROME":
                    driverManager = new ChromeDriverManager();
                    break;
                case "FIREFOX":
                    driverManager = new FirefoxDriverManager();
                    break;
                default:
                    driverManager = null;
                    break;
            }
            return driverManager;
        }
    }

}