using System;
using CreatingReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using Resources;

namespace UltimateQAPractice
{
    public class BaseTest
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public IWebDriver Driver { get; private set; }
        public TestContext TestContext { get; set; }
        private ScreenshotTaker ScreenshotTaker { get; set; }

        [TestInitialize]
        public void SetupBeforeEveryTestMethod()
        {
            Logger.Debug("*************************************** TEST STARTED");
            Logger.Debug(GetType().FullName + " started a method Initialize");
            //Reporter.StartReporter();
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext);
            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
            Driver.Manage().Window.Maximize();
            ScreenshotTaker = new ScreenshotTaker(Driver, TestContext);
        }

        [TestCleanup]
        public void CleanupAfterEveryTestMethod()
        {
            Logger.Debug(GetType().FullName + " started a method tear down");
            try
            {
                TakeScreenshotForTestFailure();
            }
            catch (Exception e)
            {
                Logger.Error(e.Source);
                Logger.Error(e.StackTrace);
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                Logger.Debug(TestContext.TestName);
                Logger.Debug("*************************************** TEST STOPPED");
                Logger.Debug("          ");
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;
            Driver.Quit();
            Driver = null;
            Logger.Trace("Browser stopped successfully.");
        }

        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                Reporter.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                Reporter.ReportTestOutcome("");
            }
        }
    }
}