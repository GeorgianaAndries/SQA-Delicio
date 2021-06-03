using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesatreSDBIS.Pages
{
    
    public class AccountPage
    {
        private IWebDriver driver;
        private string accountButton = "//p[@class='form-row']//button[contains(@name, 'login')]";
        private string userIcon = "//i[contains(@class, 'far fa-user')]";
        private string errorMessage = "//ul[contains(@class,'woocommerce-error')]/li";
        private string userNameInput = "//input[contains(@name, 'password')]";

        public AccountPage(IWebDriver browser)
        {
            this.driver = browser;
        }

        public void clickOnAuthenticate()
        {
            driver.FindElement(By.XPath(accountButton)).Click();
        }
        
        public void clickOnUserIcon()
        {
            driver.FindElement(By.XPath(userIcon)).Click();
        }

        public string getErrorMessage()
        {
            return driver.FindElement(By.XPath(errorMessage)).Text;
        }
        
        public void waitAccountButtonToBeClickable()
        {
            Utils.WaitElementToBeFound(driver, accountButton, 10);
        }
        
        public void switchTab()
        {
            var popup = driver.WindowHandles[1]; // handler for the new tab
            driver.SwitchTo().Window(driver.WindowHandles[0]).Close(); // close the tab
        }
    }
}
