using System;
using OpenQA.Selenium;
using webdriver_test2.components;

namespace webdriver_test2.PO
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            
        }

        public Link loginBtn {
            get { return new Link(this.driver, By.Id("loginLink")); }
        }
    }
}

