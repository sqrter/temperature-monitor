using System;
using System.Collections.Generic;
using System.Linq;
using Common.Entities;
using Common.Messages;
using Common.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.DateTime;
using static System.TimeSpan;

namespace Tests.Services
{
    public abstract class AverageServiceTests
    {
        protected double Hreshold = 5.0;
        protected TimeSpan AverageActualPeriod = FromSeconds(3);

        protected IAverageService Sut;

        [TestMethod]
        public void Constructor_InitRequiredProperties()
        {
            //assert
            Sut.AverageActualPeriod.Should().Be(AverageActualPeriod);
            Sut.Threshold.Should().Be(Hreshold);
        }

        [TestMethod]
        public void AddValue_AddValueIntoAverage()
        {
            //arrange
            Sut.Average(UtcNow).Should().NotHaveValue();
            //act
            Sut.AddValue(1, new TemperatureValue(2.0, UtcNow), null);
            //assert
            Sut.Average(UtcNow).Should().Be(2.0);
        }

        [TestMethod]
        public void AddValue_UpdateExistedValue()
        {
            //arrange
            Sut.Average(UtcNow).Should().NotHaveValue();
            //act
            Sut.AddValue(1, new TemperatureValue(2.0, UtcNow), null);
            Sut.AddValue(1, new TemperatureValue(4.0, UtcNow), null);
            //assert
            Sut.Average(UtcNow).Should().Be(4.0);
        }

        [TestMethod]
        public void AddValue_NotGenerateEventIfValueLessThanThresold()
        {
            //arrange
            object message = null;
            //act
            Sut.AddValue(1, new TemperatureValue(2.0, UtcNow), (msg) => message = msg);
            //assert
            message.Should().BeNull();
        }

        [TestMethod]
        public void AddValue_GenerateEventIfValueHitsThresold()
        {
            //arrange
            object message = null;
            //act
            Sut.AddValue(1, new TemperatureValue(Hreshold - 1, UtcNow), null);
            Sut.AddValue(1, new TemperatureValue(Hreshold, UtcNow), (msg) => message = msg);
            //assert
            message.Should().Equals(new ThresholdExceeded(1));
        }

        [TestMethod]
        public void AddValue_NotGenerateEventIfValueStayExceeded()
        {
            //arrange
            object message = null;
            //act
            Sut.AddValue(1, new TemperatureValue(Hreshold, UtcNow), null);
            Sut.AddValue(1, new TemperatureValue(Hreshold + 1, UtcNow), (msg) => message = msg);
            //assert
            message.Should().BeNull();
        }

        [TestMethod]
        public void AddValue_GenerateEventIfValueGetsBackToNormal()
        {
            //arrange
            object message = null;
            //act
            Sut.AddValue(1, new TemperatureValue(Hreshold + 1, UtcNow), null);
            Sut.AddValue(1, new TemperatureValue(Hreshold - 1, UtcNow), (msg) => message = msg);
            //assert
            message.Should().Equals(new ValueNormalized(1));
        }

        [TestMethod]
        public void AddValue_GenerateExceedEventEvenIfPreviousValueIsOutdated()
        {
            //arrange
            object message = null;
            //act
            Sut.AddValue(1, new TemperatureValue(Hreshold - 1, UtcNow - FromSeconds(5)), null);
            Sut.Average(UtcNow).Should().NotHaveValue();
            Sut.AddValue(1, new TemperatureValue(Hreshold, UtcNow), (msg) => message = msg);
            //assert
            message.Should().Equals(new ThresholdExceeded(1));
        }

        [TestMethod]
        public void AddValue_GenerateNormalizeEventEvenIfPreviousValueIsOutdated()
        {
            //arrange
            object message = null;
            //act
            Sut.AddValue(1, new TemperatureValue(Hreshold + 1, UtcNow - FromSeconds(5)), null);
            Sut.Average(UtcNow).Should().NotHaveValue();
            Sut.AddValue(1, new TemperatureValue(Hreshold - 1, UtcNow), (msg) => message = msg);
            //assert
            message.Should().Equals(new ValueNormalized(1));
        }

        [TestMethod]
        public void Average_ReturnZeroIfNothingToCount()
        {
            //act
            var result = Sut.Average(UtcNow);
            //assert
            result.Should().NotHaveValue();
        }

        [TestMethod]
        public void Average_ReturnAverageValue()
        {
            //arrange
            var list = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 };
            foreach (double t in list)
            {
                Sut.AddValue((int)t, new TemperatureValue(t, UtcNow), null);
            }
            //act
            var result = Sut.Average(UtcNow);
            //assert
            result.Should().Be(list.Average());
        }

        [TestMethod]
        public void Average_ReturnAverageValueUsingOnlyActualValues()
        {
            //arrange
            var list = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 };
            foreach (double t in list)
            {
                var longerPeriod = AverageActualPeriod.Add(AverageActualPeriod);
                Sut.AddValue((int)t, new TemperatureValue(t,
                    t < 3.0 ? UtcNow - longerPeriod : UtcNow), null);
            }
            //act
            var result = Sut.Average(UtcNow);
            //assert
            result.Should().Be(list.Where(x => x >= 3).Average());
        }

        [TestMethod]
        public void Average_ExcludePreviousValueWithTheSameId()
        {
            //arrange
            var testData = new List<Tuple<int, TemperatureValue>>
            {
                new Tuple<int, TemperatureValue>(1, new TemperatureValue(1, UtcNow)),
                new Tuple<int, TemperatureValue>(2, new TemperatureValue(2, UtcNow)),
                new Tuple<int, TemperatureValue>(1, new TemperatureValue(3, UtcNow)),
                new Tuple<int, TemperatureValue>(2, new TemperatureValue(4, UtcNow)),
                new Tuple<int, TemperatureValue>(3, new TemperatureValue(5, UtcNow))
            };
            foreach (var tuple in testData)
            {
                Sut.AddValue(tuple.Item1, tuple.Item2, null);
            }
            //act
            var result = Sut.Average(UtcNow);
            //assert
            result.Should().Be(new[] { 3, 4, 5 }.Average());
        }

    }
}
