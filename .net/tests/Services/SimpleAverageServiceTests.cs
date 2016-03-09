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
            sut = new SimpleAverageService(_hreshold, _averageActualPeriod);
        }
    }
}
