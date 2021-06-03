using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestareDelicio
{
	[TestClass]
	public class TestUpdateDetaliiCont
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
		public void UpdateDetaliiCont()
		{	//Intru in setarile contului
			IWebElement elementToClick = driver.FindElement(By.XPath("//*[text()='Contul meu']"));
			var js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("window.scrollTo(0," + elementToClick.Location.Y + ")");
			elementToClick.Click();

			//inregistrez un nou user
			driver.FindElement(By.Id("reg_email")).SendKeys("bya@gmail.com");

			driver.FindElement(By.Name("register")).Click();

			//click la adrese
			driver.FindElement(By.XPath("//*[text()='Detalii cont']")).Click();



			
			driver.FindElement(By.Id("account_first_name")).SendKeys("Bianca");
			driver.FindElement(By.Id("account_last_name")).SendKeys("Calancea");
			
			IWebElement elementToClick2 = driver.FindElement(By.XPath("//*[text()='Salvează modificările']"));
			var js2 = (IJavaScriptExecutor)driver;
			js2.ExecuteScript("window.scrollTo(0," + elementToClick2.Location.Y + ")");
			elementToClick2.Click();
			var expectedResult = "Detaliile contului au fost schimbate cu succes. ";
			var actualResults = driver.FindElement(By.XPath("//*[text()='Detaliile contului au fost schimbate cu succes. ']")).Text;
			Assert.AreEqual(expectedResult, actualResults);





		}

		[TestCleanup]
		public void CleanUp()
		{
			driver.Quit();
		}
	}
}
