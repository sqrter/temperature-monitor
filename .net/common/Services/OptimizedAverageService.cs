using System;
using System.Collections.Generic;
using Common.Entities;

namespace Common.Services
{
    public class OptimizedAverageService : AbstractAverageService
    {
        private class TemperatureData
        {
            public TemperatureData(double value, int countInQueue)
            {
                Temperature = value;
                CountInQueue = countInQueue;
            }

            public double Temperature { get; private set; }
            public int CountInQueue { get; private set; }

            public TemperatureData UpdateTemperature(double temperature)
            {
                Temperature = temperature;
                return this;
            }

            public TemperatureData InrementCount()
            {
                CountInQueue += 1;
                return this;
            }

            public TemperatureData DecrementCount()
            {
                CountInQueue = CountInQueue > 0 ? CountInQueue - 1 : 0;
                return this;
            }
        }

        private struct Total
        {
            public Total(int devicesCount, double temperatureSumm)
            {
                DevicesCount = devicesCount;
                TemperatureSumm = temperatureSumm;
            }
            public int DevicesCount { get; }
            public double TemperatureSumm { get; }
        }

        private readonly Dictionary<long, TemperatureData> data = new Dictionary<long, TemperatureData>();

        private Total counter = new Total(0, 0.0);

        private readonly Queue<Tuple<long, double, DateTime>> actualValues = new Queue<Tuple<long, double, DateTime>>();

        public OptimizedAverageService(double threshold, TimeSpan averageActualPeriod)
            : base(threshold, averageActualPeriod)
        { }

        public override void AddValue(long deviceId, TemperatureValue value, Action<bool> callback = null)
        {
            if (data.ContainsKey(deviceId))
            {
                var previousValue = data[deviceId].Temperature;
                if (previousValue < Threshold && value.Temperature >= Threshold)
                    callback?.Invoke(true);
                if (previousValue >= Threshold && value.Temperature < Threshold)
                    callback?.Invoke(false);
            }
            else
            {
                if (value.Temperature >= Threshold)
                    callback?.Invoke(true);
            }
            SetTemperature(deviceId, value);
        }

        public override double? Average(DateTime currenTime)
        {
            while (counter.DevicesCount > 0)
            {
                var firstOut = actualValues.Peek();
                if (firstOut.Item3 < currenTime - AverageActualPeriod)
                {
                    var temperatureData = data[firstOut.Item1];
                    if (temperatureData.CountInQueue == 1)
                    {
                        temperatureData.DecrementCount();
                        counter = new Total(counter.DevicesCount - 1,
                            counter.TemperatureSumm - temperatureData.Temperature);
                        data[firstOut.Item1].UpdateTemperature(0);
                    }
                    actualValues.Dequeue();
                }
                else
                {
                    break;
                }
            }
            return counter.DevicesCount == 0 ? (double?)null : Math.Round(counter.TemperatureSumm / counter.DevicesCount, 5);
        }

        private void SetTemperature(long deviceId, TemperatureValue value)
        {
            if (data.ContainsKey(deviceId) && data[deviceId].CountInQueue > 0)
            {
                counter = new Total(counter.DevicesCount,
                    counter.TemperatureSumm - data[deviceId].Temperature + value.Temperature);

                data[deviceId].InrementCount().UpdateTemperature(value.Temperature);
            }
            else
            {
                data[deviceId] = new TemperatureData(value.Temperature, 1);
                counter = new Total(counter.DevicesCount + 1, counter.TemperatureSumm + value.Temperature);
            }
            actualValues.Enqueue(Tuple.Create(deviceId, value.Temperature, value.Timestamp));
        }

    }
}
