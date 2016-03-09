using System;
using System.Collections.Generic;
using System.Linq;
using Common.Entities;
using Common.Messages;
using Common.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Services
{
    public abstract class AverageServiceTests
    {
        protected double _hreshold = 5.0;
        protected TimeSpan _averageActualPeriod = TimeSpan.FromSeconds(3);

        protected IAverageService sut;

        [TestMethod]
        public void Constructor_InitRequiredProperties()
        {
            //assert
            sut.AverageActualPeriod.Should().Be(_averageActualPeriod);
            sut.Threshold.Should().Be(_hreshold);
        }

        [TestMethod]
        public void AddValue_AddValueIntoAverage()
        {
            //arrange
            sut.Average().Should().Be(0);
            //act
            sut.AddValue(1, new TemperatureValue(2.0, DateTime.UtcNow), null);
            //assert
            sut.Average().Should().Be(2.0);
        }

        [TestMethod]
        public void AddValue_UpdateExistedValue()
        {
            //arrange
            sut.Average().Should().Be(0);
            //act
            sut.AddValue(1, new TemperatureValue(2.0, DateTime.UtcNow), null);
            sut.AddValue(1, new TemperatureValue(4.0, DateTime.UtcNow), null);
            //assert
            sut.Average().Should().Be(4.0);
        }

        [TestMethod]
        public void AddValue_NotGenerateEventIfValueLessThanThresold()
        {
            //arrange
            object message = null;
            //act
            sut.AddValue(1, new TemperatureValue(2.0, DateTime.UtcNow), (msg) => message = msg);
            //assert
            message.Should().BeNull();
        }

        [TestMethod]
        public void AddValue_GenerateEventIfValueHitsThresold()
        {
            //arrange
            object message = null;
            //act
            sut.AddValue(1, new TemperatureValue(_hreshold - 1, DateTime.UtcNow), null);
            sut.AddValue(1, new TemperatureValue(_hreshold, DateTime.UtcNow), (msg) => message = msg);
            //assert
            message.Should().Equals(new ThresholdExceeded(1));
        }

        [TestMethod]
        public void AddValue_NotGenerateEventIfValueStayExceeded()
        {
            //arrange
            object message = null;
            //act
            sut.AddValue(1, new TemperatureValue(_hreshold, DateTime.UtcNow), null);
            sut.AddValue(1, new TemperatureValue(_hreshold + 1, DateTime.UtcNow), (msg) => message = msg);
            //assert
            message.Should().BeNull();
        }

        [TestMethod]
        public void AddValue_GenerateEventIfValueGetsBackToNormal()
        {
            //arrange
            object message = null;
            //act
            sut.AddValue(1, new TemperatureValue(_hreshold + 1, DateTime.UtcNow), null);
            sut.AddValue(1, new TemperatureValue(_hreshold - 1, DateTime.UtcNow), (msg) => message = msg);
            //assert
            message.Should().Equals(new ValueNormalized(1));
        }

        [TestMethod]
        public void Average_ReturnZeroIfNothingToCount()
        {
            //act
            var result = sut.Average();
            //assert
            result.Should().Be(0);
        }

        [TestMethod]
        public void Average_ReturnAverageValue()
        {
            //arrange
            var list = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 };
            for (int i = 0; i < list.Count; i++)
            {
                sut.AddValue((int)list[i], new TemperatureValue(list[i], DateTime.UtcNow), null);
            }
            //act
            var result = sut.Average();
            //assert
            result.Should().Be(list.Average());
        }

        [TestMethod]
        public void Average_ReturnAverageValueUsingOnlyActualValues()
        {
            //arrange
            var list = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 };
            for (int i = 0; i < list.Count; i++)
            {
                var longerPeriod = _averageActualPeriod.Add(_averageActualPeriod);
                sut.AddValue((int)list[i], new TemperatureValue(list[i],
                    list[i] < 3.0 ? DateTime.UtcNow - longerPeriod : DateTime.UtcNow), null);
            }
            //act
            var result = sut.Average();
            //assert
            result.Should().Be(list.Where(x => x >= 3).Average());
        }
    }
}
