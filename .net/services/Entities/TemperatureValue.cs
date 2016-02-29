using System;

namespace Services.Entities
{
    public class TemperatureValue
    {
        public TemperatureValue(double value, DateTime timestamp)
        {
            Temperature = value;
            Timestamp = timestamp;
        }

        public double Temperature { get; }
        public DateTime Timestamp { get; }
    }
}
