using OpenQA.Selenium;


namespace DelicioTests.PageObjects
{
    class AccountPage
    {
        private IWebDriver driver;

        public AccountPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By UserEmail = By.XPath("/html/body/div[2]/div/div/section[2]/div/div/div/div/div/div/div/div/div/div/p[1]/strong[1]");
        public IWebElement LblUserEmail => driver.FindElement(UserEmail);

    }
}
