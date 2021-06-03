using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TesatreSDBIS.Pages;

namespace TemaTestare1
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver driver;
        private MenuPage menuPage;
        private LandingPage landingPage;
        private AccountPage accountPage;
        private readonly string expectedErrorMessage = "Eroare: Numele de utilizator este obligatoriu.";
        private string actualMessage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            menuPage = new MenuPage(driver);
            accountPage = new AccountPage(driver);
            landingPage = new LandingPage(driver);
            driver.Manage().Window.Maximize();
            landingPage.navigateToDelicioSite();
        }


        [TestMethod]
        public void Error_message_appears_when_login_with_no_credentials()
        {
            accountPage.clickOnUserIcon();

            accountPage.switchTab();
            accountPage.clickOnAuthenticate();

            actualMessage = accountPage.getErrorMessage();

            Assert.IsTrue(actualMessage.Contains(expectedErrorMessage),
                "The incorrect login error message is not correct");
        }

        [TestCleanup]
        public void cleanUp()
        {
            driver.Quit();
        }
    }
}
