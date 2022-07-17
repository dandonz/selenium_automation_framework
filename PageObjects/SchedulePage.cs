using System;
using OpenQA.Selenium;

namespace PageObjects
{
    public class SchedulePage : BasePage
    {
        private readonly By _pageTitle = By.TagName("h1");
        public SchedulePage(IWebDriver driver) : base(driver) { }
        public string getPageTile()
        {
            return GetElement(_pageTitle).Text;
        }
    }
}
