using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TesatreSDBIS
{
    public static class Utils
    {

        public static IWebElement WaitElementToBeFound(this IWebDriver driver, string by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(By.XPath(by)));
            }
            return driver.FindElement(By.XPath(by));
        }
    }
}
