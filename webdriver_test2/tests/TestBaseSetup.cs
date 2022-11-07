using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using webdriver_test2.helpers;
using System.IO;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using OpenQA.Selenium.DevTools;

//using DevToolsSessionDomains = OpenQA.Selenium.DevTools.V107.DevToolsSessionDomains;
//using Network = OpenQA.Selenium.DevTools.V107.Network;

[assembly:Parallelizable(ParallelScope.Fixtures)]

namespace webdriver_test2
{
    public class TestBaseSetup
    {

        public IWebDriver driver;

        protected IDevTools devTools;
        protected IDevToolsSession session;
        protected DevToolsSessionDomains domains;

        [OneTimeSetUp]
        public void StartTest()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [SetUp]
        public void BaseSetup()
        {
            Console.WriteLine("Setup the driver ...");
            String dir = NUnit.Framework.TestContext.CurrentContext.TestDirectory;
            var root = System.IO.Directory.GetParent(dir).Parent.FullName.Replace("/bin", string.Empty);
            var dotenv = Path.Combine(root, ".env");
            DotEnvHelper.Load(dotenv);
            
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddAdditionalOption("selenoid:options", new Dictionary<string, object>
            {
                /* How to add test badge */
                ["name"] = NUnit.Framework.TestContext.CurrentContext.Test.Name,
                ["description"] = "AAA BBB",

                /* How to set session timeout */
                ["sessionTimeout"] = "15m",
                /* How to add "trash" button */
                ["labels"] = new Dictionary<string, object>
                {
                    ["manual"] = "true"
                },
                ["enableVnc"] = true
            });
            driver = new RemoteWebDriver(new Uri(Environment.GetEnvironmentVariable("grid_url")), chromeOptions);
            driver.Manage().Window.Maximize();

            //this.devTools = this.driver as IDevTools;
            //this.session = devTools.GetDevToolsSession();
            //this.domains = session.GetVersionSpecificDomains<DevToolsSessionDomains>();
            //domains.Network.Enable(new Network.EnableCommandSettings());
            // https://groups.google.com/g/selenium-users/c/7o_WWrlaRHU/m/aCp7nQeXAQAJ
            // https://github.com/SeleniumHQ/selenium/issues/9956
        }

        [TearDown]
        public void BaseTearDown()
        {
            //Thread.Sleep(30000);
            driver.Quit();
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            Trace.Flush();
        }
    }
}

