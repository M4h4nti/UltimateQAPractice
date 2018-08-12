using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UltimateQAPractice
{
    [TestClass]
    [TestCategory("Search")]
    public class SearchFunctionality : BaseTest
    {
        [TestMethod]
        [Description("Method to test search bar functionality on home page...")]
        [TestProperty("Author","VJKumar")]
        public void TCID1()
        {
            var homePage = new HomePage(Driver);
            homePage.GoTo();
            var searchPage = homePage.SearchForItem("blouse");
            Assert.IsTrue(searchPage.Item.Displayed);           
        }       
    }
}
