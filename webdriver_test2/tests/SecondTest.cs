using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using webdriver_test2.PO;

namespace webdriver_test2
{
    public class SecondTest : TestBaseSetup
    {
        HomePage homePage;
        LoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
        }


        [Test]
        [TestCase(TestName = "Secons Test", Description = "This test uses a simple input value")]
        public void Test1()
        {
            homePage.open();
            homePage.loginBtn.click();
            loginPage.userName.fill(Environment.GetEnvironmentVariable("user_name"));
            loginPage.password.fill(Environment.GetEnvironmentVariable("user_password"));
            loginPage.loginBtn.click();
            Assert.Pass();
        }
    }
}
