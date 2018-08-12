using System;
using AventStack.ExtentReports;
using CreatingReports;
using OpenQA.Selenium;

namespace UltimateQAPractice
{
    internal class ContactUsPage : BasePage
    {
        //private readonly IWebDriver driver;

        public ContactUsPage(IWebDriver driver) : base(driver)
        {}

        public IWebElement ContactForm
        {
            get
            {
                try
                {
                    Reporter.LogTestStepForBugLogger(Status.Info, "Validate contact form in contact us page");
                    return driver.FindElement(By.ClassName("contact-form-box"));                    
                }
                catch (NoSuchElementException)
                {
                    throw new ArgumentException("No Such Element Exixts...");
                }                
            }

        }

        internal void GoTo()
        {
            Reporter.LogTestStepForBugLogger(Status.Info, "Validate Open Contact Us Page..");
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=contact");
            Reporter.LogTestStepForBugLogger(Status.Info, "Contact Us Page Open..");
        }

        public bool IsDisplayed => driver.FindElement(By.Id("columns")).Displayed;
    }
}