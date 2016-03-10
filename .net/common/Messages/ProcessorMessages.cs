using System;

namespace Common.Messages
{
    public class CalculateAverage { }

    public class AverageTemperature
    {
        public AverageTemperature(double? value)
        {
            Value = value;
        }

        public double? Value { get; }
    }

    public class ThresholdExceeded
    {
        public ThresholdExceeded(long deviceId)
        {
            DeviceId = deviceId;
        }

        public long DeviceId { get; }
    }

    public class ValueNormalized
    {
        public ValueNormalized(long deviceId)
        {
            DeviceId = deviceId;
        }

        public long DeviceId{ get; }
    }
}
