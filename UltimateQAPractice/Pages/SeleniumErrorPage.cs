using OpenQA.Selenium;

namespace UltimateQAPractice.Tests
{
    public class SeleniumErrorPage : BasePage
    {      
        public SeleniumErrorPage(IWebDriver driver) :base(driver)
        {}

        public bool IsDisplayed
        {
            get
            {
                driver.PageSource.Contains("selenium errors");
                return true;
            }
        }
    }
}