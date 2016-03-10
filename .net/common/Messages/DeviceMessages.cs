using System;

namespace Common.Messages
{
    public class Iterate
    {
        public Iterate(double temperature)
        {
            Temperature = temperature;
        }

        public double Temperature { get; }
    }

    public class DeviceTemperature
    {
        public DeviceTemperature(long deviceId, double value)
        {
            DeviceId = deviceId;
            Value = value;
        }

        public long DeviceId { get; }

        public double Value { get; }
    }
}