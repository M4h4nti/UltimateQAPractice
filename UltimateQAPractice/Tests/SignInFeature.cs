using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UltimateQAPractice.Tests
{
    [TestClass]
    [TestCategory("Sign In")]
    public class SignInFeature : BaseTest
    {
        [TestMethod]
        [Description("Validate Sign In page from homepage signin button")]
        [TestProperty("Author","VJKumar")]
        public void TCID5()
        {
            var homepage = new HomePage(Driver);
            homepage.GoTo();
            var signInPage = homepage.ClickOnSignInButton();
            Assert.IsTrue(signInPage.IsDisplayed);
        }
    }
}
