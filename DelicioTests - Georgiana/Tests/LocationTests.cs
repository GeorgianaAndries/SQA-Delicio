using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using DelicioTests.PageObjects;
using System.Threading;

namespace DelicioTests.Tests
{
    [TestClass]
    public class LocationTests
    {
        private IWebDriver driver;
        private LocationPage locationPage;

        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            locationPage = new LocationPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://delicio.ro/");
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void Should_Open_Page_For_Iasi_Location()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div/section[2]/div[2]/div/div/section/div/div[2]/div/div/div/div/a")).Click();
            Assert.AreEqual(driver.FindElement(By.XPath("/html/body/div[1]/div/section[3]/div/div/div[1]/div/div/div/div/div/h3")).Text, "Iași");
        }

        [TestMethod]
        public void Should_Fail_If_Opened_Page_Isnt_Iasi()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div/div/section[2]/div[2]/div/div/section/div/div[2]/div/div/div/div/a")).Click();
            Assert.AreNotEqual(driver.FindElement(By.XPath("/html/body/div[1]/div/section[3]/div/div/div[1]/div/div/div/div/div/h3")).Text, "Iasi");
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

    }
}
