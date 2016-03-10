using Common.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Services
{
    [TestClass]
    public class SimpleAverageServiceTests : AverageServiceTests
    {
        [TestInitialize]
        public void TestInit()
        {
            Sut = new SimpleAverageService(Hreshold, AverageActualPeriod);
        }
    }
}
