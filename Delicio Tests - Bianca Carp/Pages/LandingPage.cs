using OpenQA.Selenium;
using System;

namespace TesatreSDBIS.Pages
{
    public class LandingPage
    {
        private string delicioSite = "https://delicio.ro/iasi/";
        private string iasiCounty = "//span[contains(text(), 'Iași')]";
        private string delicioSiteContact = "https://delicio.ro/iasi/contact/";

        private IWebDriver driver;


        public LandingPage(IWebDriver browser)
        {
            this.driver = browser;
        }

        public void navigateToDelicioSite()
        {
            driver.Navigate().GoToUrl(delicioSite);
        }
       
        public void navigateToDelicioContactPage()
        {
            driver.Navigate().GoToUrl(delicioSiteContact);
        }
        
        public void clickOnIasi()
        {
            driver.FindElement(By.LinkText(iasiCounty)).Click();
        }
    }
}
