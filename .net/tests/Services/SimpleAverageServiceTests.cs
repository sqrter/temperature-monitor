using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemperatureMonitor.Services;

namespace Tests
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
