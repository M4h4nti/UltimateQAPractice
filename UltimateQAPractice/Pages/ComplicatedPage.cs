using System;
using AventStack.ExtentReports;
using CreatingReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UltimateQAPractice.Tests
{
    internal class ComplicatedPage : BasePage
    {
        public bool SuccessElementIsDisplayed => driver.FindElement(By.ClassName("et-pb-contact-message")).Displayed;
        
        public ComplicatedPage(IWebDriver driver) :base(driver)
        {}
        
        internal void GoTo()
        {
            Reporter.LogTestStepForBugLogger(Status.Info, "Opening Complicated page of ultimateQA");
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/complicated-page/");
            Reporter.LogTestStepForBugLogger(Status.Info, "Validate the page...");
            driver.Url.Contains("complicated page");
            Reporter.LogTestStepForBugLogger(Status.Info,"Page opened Succesfully");
        }

        internal void FillFormAndSubmit()
        {
            Reporter.LogTestStepForBugLogger(Status.Info, "Wait to load the elements");
            WaitUntilElementVisible(By.XPath("//*[@class='et_pb_contact_form clearfix']"));
            Reporter.LogTestStepForBugLogger(Status.Info, "Elements loaded after wait and about to fill...");
            driver.FindElement(By.Id("et_pb_contact_name_1")).SendKeys("Mahi");
            driver.FindElement(By.Id("et_pb_contact_email_1")).SendKeys("Mahi@dwd.com");
            driver.FindElement(By.Id("et_pb_contact_message_1")).SendKeys("Hi");
            AnswerCaptcha();
            Reporter.LogPassingTestStepToBugLogger("Form submitted successfuly");
        }

        internal SeleniumErrorPage SearchFor(string itemToSearchFor)
        {
            Reporter.LogTestStepForBugLogger(Status.Info, "Searching for selenium error page");
            driver.FindElement(By.Id("s")).SendKeys(itemToSearchFor);
            Reporter.LogPassingTestStepToBugLogger($"Search for {itemToSearchFor} is successful...");
            return new SeleniumErrorPage(driver);
        }

        private void AnswerCaptcha()
        {
            Reporter.LogTestStepForBugLogger(Status.Info, "Enter answer for captcha...");
            IWebElement captchaQuestion = driver.FindElement(By.Name("et_pb_contact_captcha_0"));
            int a = Convert.ToInt32(captchaQuestion.GetAttribute("data-first_digit"));
            int b = Convert.ToInt32(captchaQuestion.GetAttribute("data-second_digit"));
            captchaQuestion.SendKeys($"{a+b}");
            driver.FindElement(By.XPath("//*[@class = 'et_pb_contact_submit et_pb_button']")).Click();
            WaitUntilElementVisible(By.ClassName("et-pb-contact-message"));
            //string captcha = driver.FindElement(By.ClassName("et_pb_contact_captcha_question")).Text;
        }
        
        private void WaitUntilElementVisible(By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));

        }
    }
}