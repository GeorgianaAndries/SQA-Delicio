using OpenQA.Selenium;

namespace DelicioTests.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement TxtEmail => driver.FindElement(By.XPath("/html/body/div[2]/div/div/section[2]/div/div/div/div/div/div/div/div/div/div[2]/div[1]/form/p[1]/input"));
        private IWebElement TxtPassword => driver.FindElement(By.XPath("/html/body/div[2]/div/div/section[2]/div/div/div/div/div/div/div/div/div/div[2]/div[1]/form/p[2]/span/input"));
        private IWebElement BtnSignIn => driver.FindElement(By.CssSelector("/html/body/div[2]/div/div/section[2]/div/div/div/div/div/div/div/div/div/div[2]/div[1]/form/p[3]/button"));

        private By FailedLabel = By.XPath("/html/body/div[2]/div/div/section[2]/div/div/div/div/div/div/div/div/div/div[1]/ul/li");
        public IWebElement LblLoginFailed => driver.FindElement(FailedLabel);

        public AccountPage LoginApplication(string email, string password)
        {
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);
            BtnSignIn.Click();
            return new AccountPage(driver);
        }
    }
}
