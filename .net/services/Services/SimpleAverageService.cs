using System;
using System.Collections.Generic;
using System.Linq;
using Services.Entities;

namespace TemperatureMonitor.Services
{
    public class SimpleAverageService : AbstractAverageService
    {
        private Dictionary<int, TemperatureValue> data = new Dictionary<int, TemperatureValue>();

        public SimpleAverageService(double threshold, TimeSpan averageActualPeriod)
            : base(threshold, averageActualPeriod)
        { }

        public override void AddValue(int deviceId, TemperatureValue value, Action<bool> callback = null)
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

        private void SetTemperature(int deviceId, TemperatureValue value) => data[deviceId] = value;

    }
}
