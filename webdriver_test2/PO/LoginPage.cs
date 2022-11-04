using System;
using OpenQA.Selenium;
using webdriver_test2.components;

namespace webdriver_test2.PO
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public Input userName {
            get { return new Input(this.driver, By.Id("UserName")); }
        }

        public Input password {
            get { return new Input(this.driver, By.Id("Password")); }
        }

        public Button loginBtn {
            get { return new Button(this.driver, By.CssSelector(".btn.btn-default")); }
        }
    }
}

