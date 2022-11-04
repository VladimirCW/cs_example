using System;
using OpenQA.Selenium;

namespace webdriver_test2.components
{
    public class Button : BaseComponent
    {
        public Button(IWebDriver driver, By element) : base(driver, element)
        {
        }
    }
}

