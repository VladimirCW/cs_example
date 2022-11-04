using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using webdriver_test2.helpers;
using System.IO;
using System.Diagnostics;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace webdriver_test2
{
    public class TestBaseSetup
    {

        public IWebDriver driver;
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        


        [SetUp]
        public void BaseSetup()
        {
            log4net.Config.XmlConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger("AAA");

            log.Info("****************************");
            NUnit.Framework.TestContext.WriteLine("^^^^^^^^^^^^^^^^^^");
            Debug.WriteLine("This is Debug.WriteLine");

            TestContext.Progress.WriteLine("This is TestContext.Progress.WriteLine");
            TestContext.Error.WriteLine("This is TestContext.Error.WriteLine");

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

