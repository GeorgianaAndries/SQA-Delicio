using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TesatreSDBIS.Pages;

namespace TesatreSDBIS.Tests
{
    [TestClass]
    public class SendMessageToContact
    {
        private IWebDriver driver;
        private LandingPage landingPage;
        private ContactPage contactPage;
        private readonly string expectedMessage = "The form was sent successfully.";
        private string actualMessage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            contactPage = new ContactPage(driver);
            landingPage = new LandingPage(driver);
            driver.Manage().Window.Maximize();
            landingPage.navigateToDelicioContactPage();
        }

        [TestMethod]
        public void Should_successfully_send_message()
        {
            contactPage.setContactName(TestData.name);
            contactPage.setContactEmail(TestData.email);
            contactPage.setContactMessage(TestData.message);
            contactPage.submitMessage();
            contactPage.waitMessageToAppear();

            actualMessage = contactPage.getSuccessfullySentMessageText();

            Assert.IsTrue(actualMessage.Contains(expectedMessage),
               "The message is not correct!");
        }

        [TestCleanup]
        public void cleanUp()
        {
            driver.Quit();
        }
    }
}
