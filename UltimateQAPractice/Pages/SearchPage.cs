using OpenQA.Selenium;

namespace UltimateQAPractice
{
    internal class SearchPage : BasePage
    {
        //private IWebDriver driver;
        public IWebElement Item => driver.FindElement(By.XPath("//*[@class='product-name' and @title ='Blouse']"));

        public SearchPage(IWebDriver driver) : base(driver)
        {}
        
    }
}