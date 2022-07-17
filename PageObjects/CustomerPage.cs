using System;
using OpenQA.Selenium;

namespace PageObjects
{
    public class CustomerPage: BasePage
    {
        private readonly By _numberofcustomerLable = By.TagName("h1");
        private readonly By _searchTextBox = By.CssSelector("input[placeholder='Type customer name']");
        private readonly By _searchButton = By.LinkText("Search");
        private readonly By _newcustomerLink = By.LinkText("New Customer"); //a[href*="/new-customer"]

        public CustomerPage(IWebDriver driver): base(driver) { }

        public string GetNumberOfCustomersText()
        {
            return GetElement(_numberofcustomerLable).Text;
        }
        public void EnterToSearchTextBox(string value)
        {
            SendKeys(_searchTextBox,value);
        }
        public void ClickSearchButton()
        {
            Click(_searchButton);
        }
        public void ClickNewCustomerLink()
        {
            Click(_newcustomerLink);
        }
    }
}
