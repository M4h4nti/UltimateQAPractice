using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UltimateQAPractice
{
    [TestClass]
    [TestCategory("HomePage")]
    public class SliderFeature : BaseTest
    {
        [TestMethod]
        [Description("Verify slider on homepage working or not...")]
        [TestProperty("Author","VJKumar")]
        public void TCID3()
        {
            var homePage = new HomePage(Driver);
            homePage.GoTo();
            var currentPic = homePage.Slider.ImageStyle;
            homePage.Slider.ClickNextButton();
            var nextPic = homePage.Slider.ImageStyle;
            Assert.AreNotEqual(currentPic, nextPic);            
        }
    }
}
