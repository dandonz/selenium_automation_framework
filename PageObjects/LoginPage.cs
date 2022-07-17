using System;
using OpenQA.Selenium; 
namespace PageObjects
{
    public class LoginPage : BasePage
    {
        private readonly By _emailTextBox = By.CssSelector("input[placeholder='Mail Address']");
        private readonly By _passwordTextBox = By.CssSelector("input[placeholder='Password']");
        private readonly By _submitButton = By.CssSelector("button[type='submit']");

        public LoginPage(IWebDriver driver): base(driver) { }

        public void EnterEmail(string email)
        {
            SendKeys(_emailTextBox, email);
        }
        public void EnterPassword(string password)
        {
            SendKeys(_passwordTextBox, password);
        }
        public void ClickSubmit()
        {
            Click(_submitButton);
        }
        public void Login(string email, string password)
        {
            EnterEmail(email);
            EnterPassword(password);
            ClickSubmit();
        }
    }
}
