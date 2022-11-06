using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace webdriver_test2.PO
{
    public abstract class BasePage
    {
        private readonly String URL_ROOT = Environment.GetEnvironmentVariable("web_url");
        protected IWebDriver driver;
        protected WebDriverWait webdriverWait;
        protected String URL_PATH;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.webdriverWait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
        }

        public virtual void open() {
            this.driver.Navigate().GoToUrl(this.URL_ROOT + ((this.URL_PATH != null && this.URL_PATH.Length > 0) ? this.URL_PATH : "") );
        }

        public void waitForAjax() {
            IJavaScriptExecutor js = (IJavaScriptExecutor)this.driver;
            this.webdriverWait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");
        }

        public void waitUntilPageLoadsCompletely() {
            IJavaScriptExecutor js = (IJavaScriptExecutor)this.driver;
            this.webdriverWait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}

