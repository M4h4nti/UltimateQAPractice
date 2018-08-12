using System;
using AventStack.ExtentReports;
using CreatingReports;
using OpenQA.Selenium;

namespace UltimateQAPractice
{
    public class Slider : BasePage
    {
        public Slider(IWebDriver driver) : base(driver)
        { }

        public string ImageStyle
        {
            get
            {
                try
                {
                    Reporter.LogTestStepForBugLogger(Status.Info, "Validate the slider change..");
                    return driver.FindElement(By.Id("homeslider")).GetAttribute("style");
                }
                catch (NoSuchElementException)
                {

                    throw new ArgumentException("No such element exists..");
                }
            }
        }
        internal void ClickNextButton()
        {
            Reporter.LogTestStepForBugLogger(Status.Info, "Clicking Next Button...");
            driver.FindElement(By.ClassName("bx-next")).Click();
            Reporter.LogTestStepForBugLogger(Status.Info, "Clicked Successfully..");
        }
    }
}