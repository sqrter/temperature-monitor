using System;
using Common.Entities;

namespace Common.Services
{
    public interface IAverageService
    {
        TimeSpan AverageActualPeriod { get; }
        double Threshold { get; }

        void AddValue(long deviceId, TemperatureValue value, Action<bool> callback);
        double Average();
    }
}