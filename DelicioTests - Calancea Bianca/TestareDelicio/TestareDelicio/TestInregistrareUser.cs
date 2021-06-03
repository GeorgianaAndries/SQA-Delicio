using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TestareDelicio
{
	
	[TestClass]
	public class TestInregistrareUser
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
		public void TestInregistrareUserNou()
		{
			IWebElement elementToClick = driver.FindElement(By.XPath("//*[text()='Contul meu']"));
			var js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("window.scrollTo(0," + elementToClick.Location.Y + ")");
			elementToClick.Click();

			driver.FindElement(By.Id("reg_email")).SendKeys("an@gmail.com");

			driver.FindElement(By.Name("register")).Click();

			var expectedResult = "an";
			var actualResults = driver.FindElement(By.XPath("//*[text()='an']")).Text;
			Assert.AreEqual(expectedResult, actualResults);
		}


		[TestMethod]
		public void TestInregistrareUserDejaExistent()
		{
			IWebElement elementToClick = driver.FindElement(By.XPath("//*[text()='Contul meu']"));
			var js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("window.scrollTo(0," + elementToClick.Location.Y + ")");
			elementToClick.Click();

			driver.FindElement(By.Id("reg_email")).SendKeys("bianca@gmail.com");

			driver.FindElement(By.Name("register")).Click();

			var expectedResult = " Este înregistrat deja un cont cu adresa ta de email. ";
			var actualResults = driver.FindElement(By.XPath("//*[text()=' Este înregistrat deja un cont cu adresa ta de email. ']")).Text;
			Assert.AreEqual(expectedResult, actualResults);
		}


		[TestCleanup]
		public void CleanUp()
		{
			driver.Quit();
		}
	}
}
