using OpenQA.Selenium;
using System;

namespace TesatreSDBIS.Pages
{
    public class MenuPage
    {
        private IWebDriver driver;
        private string pizzaSelectButton = "//img[contains(@title, 'delicio-margherita')]";
        private string pizzaMargherita = "//img[contains(@title, 'delicio-margherita')]";
        private string addToCartButton = "//div[contains(@class, 'add-to-cart variations_button')]//button[@type='submit']";
        private string confirmationMessage = "//div[contains(@class, 'alert')]//strong";

        public MenuPage(IWebDriver browser)
        {
            this.driver = browser;
        }

        public void waitMenuItemToBeDisplayed()
        {
            Utils.WaitElementToBeFound(driver, pizzaMargherita, 10);
        }
        
        public void waitItemBeforeAddingToCart()
        {
            Utils.WaitElementToBeFound(driver, addToCartButton, 10);
        }

        public void selectPizza()
        {
            driver.FindElement(By.XPath(pizzaSelectButton)).Click();
        }
        
        public void addingToCart()
        {
            driver.FindElement(By.XPath(addToCartButton)).Click();
        }
        
        public string getConfirmationMessage()
        {
            return driver.FindElement(By.XPath(confirmationMessage)).Text;
        }
    }
}
