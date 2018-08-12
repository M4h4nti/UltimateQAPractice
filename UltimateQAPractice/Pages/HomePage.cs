using System;
using AventStack.ExtentReports;
using CreatingReports;
using OpenQA.Selenium;

namespace UltimateQAPractice
{
    internal class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            Slider = new Slider(driver);
        }

        public Slider Slider { get; internal set; }

        public void GoTo()
        {
            Reporter.LogTestStepForBugLogger(Status.Info, "Validate Go to Homepage...");
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Reporter.LogTestStepForBugLogger(Status.Info, "Homepage Opened..");
        }

        internal SignInPage ClickOnSignInButton()
        {
            Reporter.LogTestStepForBugLogger(Status.Info, "Click on SignIn button on homepage...");
            driver.FindElement(By.ClassName("login")).Click();
            Reporter.LogPassingTestStepToBugLogger("Button clicked and signin page opened successfully...");
            return new SignInPage(driver);
        }

        public SearchPage SearchForItem(string itemToSearch)
        {
            Reporter.LogTestStepForBugLogger(Status.Info, "Validate search item can be searched on homepage search bar...");
            driver.FindElement(By.Id("search_query_top")).SendKeys(itemToSearch);
            driver.FindElement(By.Name("submit_search")).Click();
            Reporter.LogPassingTestStepToBugLogger($"Search for {itemToSearch} is success on home page.");
            return new SearchPage(driver);
        }

        internal ContactUsPage ClickOnContactUsButton()
        {
            Reporter.LogTestStepForBugLogger(Status.Info, "Click on contactus page button...");
            driver.FindElement(By.XPath("//*[@title= 'Contact Us']")).Click();
            Reporter.LogPassingTestStepToBugLogger("Button clicked succesfully and page opened...");
            return new ContactUsPage(driver);
        }
    }
}