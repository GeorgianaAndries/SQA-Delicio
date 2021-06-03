using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TesatreSDBIS.Pages;

namespace TesatreSDBIS
{
    [TestClass]
    public class AddToCartTest
    {
        private IWebDriver driver;
        private MenuPage menuPage;
        private LandingPage landingPage;
        private readonly string expectedConfirmationMessage = "Produsul a fost adaugat in cos";
        private string actualMessage;


        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            menuPage = new MenuPage(driver);
            landingPage = new LandingPage(driver);
            driver.Manage().Window.Maximize();
            landingPage.navigateToDelicioSite();
        }

        [TestMethod]
        public void Should_add_to_cart_successfully()
        {
            menuPage.waitMenuItemToBeDisplayed();
            menuPage.selectPizza();

            menuPage.waitItemBeforeAddingToCart();
            menuPage.addingToCart();

            actualMessage = menuPage.getConfirmationMessage();

            Assert.IsTrue(actualMessage.Contains(expectedConfirmationMessage), 
                "The messages are not the same");
        }

        [TestCleanup]
        public void cleanUp()
        {
            driver.Quit();
        }
    }
}
