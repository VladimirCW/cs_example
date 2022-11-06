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
[assembly:Parallelizable(ParallelScope.Fixtures)]

namespace webdriver_test2
{
    public class TestBaseSetup
    {

        public IWebDriver driver;


        [SetUp]
        public void BaseSetup()
        {
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
        }

        [TearDown]
        public void BaseTearDown()
        {
            Thread.Sleep(30000);
            driver.Quit();
        }
    }
}

