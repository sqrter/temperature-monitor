using Common.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Services
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
