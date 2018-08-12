using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UltimateQAPractice
{
    [TestClass]
    [TestCategory("ContactUs")]
    public class ContactUsFeatures : BaseTest
    {
        [TestMethod]
        [Description("Test Method for contact form to show up...")]
        [TestProperty("Author", "VJKumar")]
        public void TCID2()
        {
            var contactUsPage = new ContactUsPage(Driver);
            contactUsPage.GoTo();
            Assert.IsTrue(contactUsPage.ContactForm.Displayed);
        }        

        [TestMethod]
        [Description("Open contact us page clicking button on home page..")]
        [TestProperty("Author","VJKumar")]
        public void TCID4()
        {
            var homePage = new HomePage(Driver);
            homePage.GoTo();
            var contactUsPage = homePage.ClickOnContactUsButton();
            Assert.IsTrue(contactUsPage.IsDisplayed);
        }
    }
}
