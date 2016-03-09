using System;
using System.Collections.Generic;
using System.Linq;
using Common.Entities;

namespace Common.Services
{
    public class SimpleAverageService : AbstractAverageService
    {
        private Dictionary<long, TemperatureValue> data = new Dictionary<long, TemperatureValue>();

        public SimpleAverageService(double threshold, TimeSpan averageActualPeriod)
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

        public override double Average()
        {
            return data.Where(kvp => kvp.Value.Timestamp > DateTime.UtcNow - AverageActualPeriod)
                                .Select(x => x.Value.Temperature).DefaultIfEmpty(0).Average();
        }

        private void SetTemperature(long deviceId, TemperatureValue value) => data[deviceId] = value;

    }
}
