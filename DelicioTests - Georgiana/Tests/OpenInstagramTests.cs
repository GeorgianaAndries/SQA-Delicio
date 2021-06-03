using DelicioTests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelicioTests.Tests
{
    [TestClass]
    class OpenInstagramTests
    {
        private IWebDriver driver;
        private HomePage homePage;
        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            homePage = new HomePage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://delicio.ro/iasi/");
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void Successfully_Open_InstagrampProfile()
        {
            homePage.OpenInstagram();
            Thread.Sleep(2000);
            var instagramPage = new HomePage(driver);
            String url = driver.Url;
            Assert.AreEqual("https://www.instagram.com/pizzadelicio/", url);
        }

        [TestMethod]
        public void Fail_If_Instagram_Not_Opened()
        {
            homePage.OpenInstagram();
            Thread.Sleep(2000);
            var instagramPage = new HomePage(driver);
            String url = driver.Url;
            Assert.AreNotEqual("https://www.instagram.com/pizzadelicio/", url);
        }
    }
}
