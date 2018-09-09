using OpenQA.Selenium;

namespace Utilities
{
    public static class WebElementExtensions
    {
        public static void EnterText(this IWebElement Element,string value)
        {
            Element.Clear();
            Element.SendKeys(value);
        }
    }
}
