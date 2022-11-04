using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using webdriver_test2.helpers;
using System.IO;

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
            driver = new RemoteWebDriver(new Uri(Environment.GetEnvironmentVariable("grid_url")), chromeOptions);
        }

        [TearDown]
        public void BaseTearDown()
        {
            driver.Quit();
        }
    }
}

