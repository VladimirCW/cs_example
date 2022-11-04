using System;
using OpenQA.Selenium;

namespace webdriver_test2.PO
{
    public abstract class BasePage
    {
        private readonly String URL_ROOT = Environment.GetEnvironmentVariable("web_url");
        protected IWebDriver driver;
        protected String URL_PATH;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public virtual void open() {
            this.driver.Navigate().GoToUrl(this.URL_ROOT + ((this.URL_PATH != null && this.URL_PATH.Length > 0) ? this.URL_PATH : "") );
        }
    }
}

