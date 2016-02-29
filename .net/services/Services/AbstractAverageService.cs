using Services.Entities;
using System;

namespace TemperatureMonitor.Services
{
    public abstract class AbstractAverageService : IAverageService
    {
        public TimeSpan AverageActualPeriod { get; }
        public double Threshold { get; }

        public AbstractAverageService(double threshold, TimeSpan averageActualPeriod)
        {
            Threshold = threshold;
            AverageActualPeriod = averageActualPeriod;
        }
        public abstract void AddValue(int deviceId, TemperatureValue value, Action<bool> callback);
        public abstract double Average();
    }
}
