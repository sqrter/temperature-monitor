using Services.Entities;
using System;

namespace TemperatureMonitor.Services
{
    public interface IAverageService
    {
        TimeSpan AverageActualPeriod { get; }
        double Threshold { get; }

        void AddValue(int deviceId, TemperatureValue value, Action<bool> callback);
        double Average();
    }
}