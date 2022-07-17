using OpenQA.Selenium;

namespace PageObjects
{
    public class NavigationBar : BasePage
    {
        private readonly By _loginLink = By.LinkText("LOG IN");
        private readonly By _logloutLink = By.LinkText("LOG OUT");
        private readonly By _loggedUserName = By.LinkText("LOG OUT");
        private readonly By _scheduleLink = By.LinkText("Schedule");
        private readonly By _assignmentLink = By.LinkText("Assignment");
        private readonly By _customersLink = By.LinkText("Customers");
        private readonly By _cleanersLink = By.LinkText("Cleaners");

        public NavigationBar(IWebDriver driver) : base(driver) { }
        public void ClickLoginLink()
        {
            Click(_loginLink);
        }
        public void ClickLogOutLink()
        {
            Click(_logloutLink);
        }
        public void ClickScheduleLink()
        {
            Click(_scheduleLink);
        }
        public void ClickAssignmentLink()
        {
            Click(_assignmentLink);
        }
        public void ClickCustomersLink()
        {
            Click(_customersLink);
        }
        public void ClickCleanersLink()
        {
            Click(_cleanersLink);
        }
        public string GetLoggedUserName()
        {
            return GetElement(_logloutLink).Text;
        }
    }
}
