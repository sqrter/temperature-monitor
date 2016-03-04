using System.Threading.Tasks;
using Orleans;
using TemperatureMonitor.Messages;

namespace GrainInterfaces
{
	public interface IPrinter: IGrainWithIntegerKey
    {
        Task PrintAverage(AverageTemperature data);
        Task ThresholdExceeded(ThresholdExceeded msg);
	    Task ValueNormalized(ValueNormalized msg);
    }
}
