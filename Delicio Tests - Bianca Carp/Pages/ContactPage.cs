using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesatreSDBIS.Pages
{
   public class ContactPage
    {
        private IWebDriver driver;
        private string contactName = "//input[@id='form-field-name']";
        private string contactEmail = "//input[@id='form-field-email']";
        private string contactMessage = "//textarea[@id='form-field-message']";
        private string submitButton = "//button[@type= 'submit']";
        private string successMessage = "//div[contains(@class, 'message-success')]";


        public ContactPage(IWebDriver browser)
        {
            this.driver = browser;
        }

        public void setContactName(string name)
        {
            driver.FindElement(By.XPath(contactName)).SendKeys(name);
        }
        public void setContactEmail(string email)
        {
            driver.FindElement(By.XPath(contactEmail)).SendKeys(email);
        }
        public void setContactMessage(string message)
        {
            driver.FindElement(By.XPath(contactMessage)).SendKeys(message);
        }
        
        public void submitMessage()
        {
            driver.FindElement(By.XPath(submitButton)).Click();
        }
        
        public string getSuccessfullySentMessageText()
        {
           return driver.FindElement(By.XPath(successMessage)).Text;
        }
        
        public void waitMessageToAppear()
        {
           Utils.WaitElementToBeFound(driver, successMessage, 10);
        }
    }
}
