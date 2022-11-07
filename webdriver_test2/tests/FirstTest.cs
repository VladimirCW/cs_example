using System;
using System.Threading;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using webdriver_test2.PO;

namespace webdriver_test2
{
    [AllureNUnit]
    public class FirstTest : TestBaseSetup
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
        [TestCase(TestName = "First Test", Description = "This test uses a simple input value")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureOwner("User")]
        [AllureSuite("PassedSuite")]
        [AllureSubSuite("NoAssert")]
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
