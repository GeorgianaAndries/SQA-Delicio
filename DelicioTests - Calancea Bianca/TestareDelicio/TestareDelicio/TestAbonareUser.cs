using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace TestareDelicio
{
	[TestClass]
	public class TestAbonareUser
	{
		private IWebDriver driver;

		[TestInitialize]
		public void SetUp()
		{
			driver = new ChromeDriver();
			//maximize window
			driver.Manage().Window.Maximize();
			//access URL of the system under test(SUT)
			driver.Navigate().GoToUrl("https://delicio.ro/iasi/");
		}
		[TestMethod]
		public void TestAbonare()
		{
			driver.FindElement(By.Id("form-field-email")).SendKeys("test@test.test");
			driver.FindElement(By.Id("form-field-name")).SendKeys("Bianca");
			driver.FindElement(By.XPath("//*[text()='ABONEAZĂ-MĂ']")).Click();
			Thread.Sleep(2000);

			var expectedResult = "The form was sent successfully.";
			var actualResults = driver.FindElement(By.XPath("//*[text()='The form was sent successfully.']")).Text;
			Assert.AreEqual(expectedResult, actualResults);
		}

		[TestCleanup]
		public void CleanUp()
		{
			driver.Quit();
		}
	}
}
