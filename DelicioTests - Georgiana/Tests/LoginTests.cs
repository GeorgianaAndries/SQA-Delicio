using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DelicioTests.PageObjects;

namespace DelicioTests.Tests
{
    [TestClass]
    class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://delicio.ro/iasi/my-account/");
            //driver.FindElement(By.XPath("/html/body/div[2]/div/div/section[2]/div/div/div/div/div/div/div/div/div/div[2]/div[1]/form/p[3]/button")).Click();
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void Successfully_login()
        {
            loginPage.LoginApplication("andries_georgiana22@yahoo.com", "kaHQAXWOu5TH");
            Thread.Sleep(2000);
            var accountPage = new AccountPage(driver);
            Assert.AreEqual("andries_georgiana22", accountPage.LblUserEmail.Text);
        }

        [TestMethod]
        public void Fail_login_invalid_credentials()
        {
            loginPage.LoginApplication("andries_georgiana22@gmail.ro", "jorj");
            Thread.Sleep(2000);
            Assert.AreEqual("Invalid credentials", loginPage.LblLoginFailed.Text);
        }

        [TestMethod]
        public void Fail_login_invalid_email()
        {
            loginPage.LoginApplication("georgiana_invalid@gmail.ro", "kaHQAXWOu5TH");
            Thread.Sleep(2000);
            Assert.AreEqual("Invalid email.", loginPage.LblLoginFailed.Text);
        }

        [TestMethod]
        public void Fail_login_invalid_password()
        {
            loginPage.LoginApplication("andries_georgiana22@yahoo.com", "invalidPW");
            Thread.Sleep(2000);
            Assert.AreEqual("Invalid password.", loginPage.LblLoginFailed.Text);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
