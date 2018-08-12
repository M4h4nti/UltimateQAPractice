using CreatingReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UltimateQAPractice
{
    [TestClass]
    public static class NamespaceSetup
    {
        [AssemblyInitialize]
        public static void ExecuteForCreatingReportsNamespace(TestContext testContext)
        {
            Reporter.StartReporter();
        }
    }
}
