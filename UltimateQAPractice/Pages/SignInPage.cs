using OpenQA.Selenium;

namespace UltimateQAPractice
{
    internal class SignInPage : BasePage
    {
        //private new readonly IWebDriver driver;

        public SignInPage(IWebDriver driver) : base(driver)
        {}

        private IWebElement AuthenticationElement => driver.FindElement(By.ClassName("page-heading"));

        public bool IsDisplayed => AuthenticationElement.Displayed;       
    }
}