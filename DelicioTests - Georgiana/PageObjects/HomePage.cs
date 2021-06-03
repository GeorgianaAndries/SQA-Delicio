using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelicioTests.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;

        private IWebElement IgButton => driver.FindElement(By.XPath("/html/body/div[3]/div/section[1]/div/div/div[5]/div/div/div[2]/div/div/p[4]/a"));

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        public HomePage OpenInstagram()
        {
            IgButton.Click();
            return new HomePage(driver);
        }
    }
}
