using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UltimateQAPractice.Tests
{
    [TestClass]
    [TestCategory("UltimateQA")]
    [TestCategory("Complicated Page")]
    public class UAComplacatedPageFeature : BaseTest
    {
        [TestMethod]
        [Description("Validate the page and submit form sucessfully")]
        [TestProperty("Author","VJKumar")]
        public void TCID6()
        {
            var complicatedPage = new ComplicatedPage(Driver);
            complicatedPage.GoTo();
            complicatedPage.FillFormAndSubmit();
            Assert.IsTrue(complicatedPage.SuccessElementIsDisplayed,"Something went wrong ... go thru the code again...");
        }

        [TestMethod]
        [Description("Search for selenium errors in search bar")]
        [TestProperty("Author","VJKumar")]
        [DataRow("selenium errors")]
        public void TCID7(string itemToSearchFor)
        {
            var complicatedPage = new ComplicatedPage(Driver);
            complicatedPage.GoTo();
            var seleniumErrorPage = complicatedPage.SearchFor(itemToSearchFor);
            Assert.IsTrue(seleniumErrorPage.IsDisplayed, "No such page is displayed");
        }
    }
}
