using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace TestareDelicio
{
	[TestClass]
	public class UnitTest1
	{
		private IWebDriver driver;
		[TestMethod]
		public void TestForSubscribe()
		{
			driver = new ChromeDriver();
			//maximize window
			driver.Manage().Window.Maximize();
			//access URL of the system under test(SUT)
			driver.Navigate().GoToUrl("https://delicio.ro/iasi/");
			driver.FindElement(By.Id("form-field-email")).SendKeys("test@test.test");
			driver.FindElement(By.Id("form-field-name")).SendKeys("Bianca");
			driver.FindElement(By.XPath("//*[text()='ABONEAZĂ-MĂ']")).Click();
			Thread.Sleep(2000);

			var expectedResult = "The form was sent successfully.";
			var actualResults = driver.FindElement(By.XPath("//*[text()='The form was sent successfully.']")).Text;
			Assert.AreEqual(expectedResult, actualResults);
		}


		[TestMethod]
		public void TestForInregistrare()
		{
			driver = new ChromeDriver();
			//maximize window
			driver.Manage().Window.Maximize();
			//access URL of the system under test(SUT)
			driver.Navigate().GoToUrl("https://delicio.ro/iasi/");

			IWebElement elementToClick = driver.FindElement(By.XPath("//*[text()='Contul meu']"));
			var js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("window.scrollTo(0," + elementToClick.Location.Y + ")");
			elementToClick.Click();

			driver.FindElement(By.Id("reg_email")).SendKeys("andra@gmail.com");

			driver.FindElement(By.Name("register")).Click();
			
			var expectedResult = "andra";
			var actualResults = driver.FindElement(By.XPath("//*[text()='andra']")).Text;
			Assert.AreEqual(expectedResult, actualResults);

		}
	}
}
