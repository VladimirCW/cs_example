using System;
using OpenQA.Selenium;

namespace webdriver_test2.components
{
    public class BaseComponent
    {
        protected IWebDriver driver;
        protected By element;

        public BaseComponent(IWebDriver driver, By element)
        {
            this.driver = driver;
            this.element = element;
        }


        public void click() {
            this.driver.FindElement(this.element).Click();
        }
    }
}

