namespace TemperatureMonitor.Messages
{
    public class CalculateAverage { }

    public class AverageTemperature
    {
        public AverageTemperature(double value)
        {
            Value = value;
        }

        public double Value { get; }
    }

    public class ThresholdExceeded
    {
        public ThresholdExceeded(int deviceId)
        {
            DeviceId = deviceId;
        }

        public int DeviceId { get; }
    }

    public class ValueNormalized
    {
        public ValueNormalized(int deviceId)
        {
            DeviceId = deviceId;
        }

        public int DeviceId{ get; }
    }
}
