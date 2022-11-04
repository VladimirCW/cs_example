using System;
using OpenQA.Selenium;

namespace webdriver_test2.components
{
    public class Input : BaseComponent
    {
        public Input(IWebDriver driver, By element) : base(driver, element)
        {
        }

        public void fill(String text) {
            this.driver.FindElement(this.element).SendKeys(text);
        }
    }
}

