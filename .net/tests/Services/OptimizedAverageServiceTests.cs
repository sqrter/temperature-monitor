using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemperatureMonitor.Services;

namespace Tests
{
    [TestClass]
    public class OptimizedAverageServiceTests : AverageServiceTests
    {
        [TestInitialize]
        public void TestInit()
        {
            sut = new OptimizedAverageService(_hreshold, _averageActualPeriod);
        }
    }
}
