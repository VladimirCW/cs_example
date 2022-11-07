using System;
using System.Net.Http;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
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
            // https://groups.google.com/g/selenium-users/c/7o_WWrlaRHU/m/aCp7nQeXAQAJ
            // https://github.com/SeleniumHQ/selenium/issues/9956
        }

        public void InterceptRequestWithFetch()
        {
            
            //var fetch = devToolsSession.GetVersionSpecificDomains<OpenQA.Selenium.DevTools.V87.DevToolsSessionDomains>().Fetch;
            //var enableCommandSettings = new OpenQA.Selenium.DevTools.V87.Fetch.EnableCommandSettings();
            //OpenQA.Selenium.DevTools.V87.Fetch.RequestPattern requestPattern = new OpenQA.Selenium.DevTools.V87.Fetch.RequestPattern();
            //requestPattern.RequestStage = OpenQA.Selenium.DevTools.V87.Fetch.RequestStage.Request;
            //requestPattern.ResourceType = ResourceType.Image;

            //enableCommandSettings.Patterns = new OpenQA.Selenium.DevTools.V87.Fetch.RequestPattern[] { requestPattern };
            //fetch.Enable(enableCommandSettings);

            //EventHandler<OpenQA.Selenium.DevTools.V87.Fetch.RequestPausedEventArgs> requestIntercepted = (sender, e) =>
            //{
            //    Console.WriteLine(e.Request.Url);
            //    fetch.ContinueRequest(new OpenQA.Selenium.DevTools.V87.Fetch.ContinueRequestCommandSettings()
            //    {
            //        RequestId = e.RequestId
            //    });
            //};
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

        public void inteceptAPI() {
            

            //domains.Network.SetBlockedURLs(
            //    new OpenQA.Selenium.DevTools.V107.Network.SetBlockedURLsCommandSettings()
            //    {
            //        Urls = new string[] { "*://*/*.css", "*://*/*.jpg", "*://*/*.css" }
            //    }
            //);
            // https://stackoverflow.com/questions/71407248/selenium-c-sharp-wait-for-background-requestsnot-initiated-by-c-sharp-code
        }

        public void WaitForRequestResponse(HttpMethod method, string uri)
        {
            //this.domains.Network.TakeResponseBodyForInterceptionAsStream
            //this.webdriverWait.Until(() =>
            //{
            //    request = GetLastSentRequest(method, uri, this.session);
            //    return request?.Response != null;
            //});

            //return request;
        }
    }
}

