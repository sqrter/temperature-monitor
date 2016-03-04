namespace TemperatureMonitor
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
        public DeviceTemperature(int deviceId, double value)
        {
            DeviceId = deviceId;
            Value = value;
        }

        public int DeviceId { get; }

        public double Value { get; }
    }
}