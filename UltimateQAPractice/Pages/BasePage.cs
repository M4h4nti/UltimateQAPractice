using CreatingReports;
using OpenQA.Selenium;

namespace UltimateQAPractice
{
    public class BasePage
    {
        public readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}