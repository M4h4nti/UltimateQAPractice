using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                //case BrowserType.Firefox:
                //    return GetFirefoxDriver();
                //case BrowserType.Edge:
                //    return GetEdgeDriver();
                default:
                    throw new ArgumentOutOfRangeException("Browser type does not exist...");
            }
        }

        private IWebDriver GetChromeDriver()
        {
            return new ChromeDriver();
        }
    }
}
