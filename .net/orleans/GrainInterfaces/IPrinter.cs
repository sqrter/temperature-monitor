using System.Threading.Tasks;
using Common.Messages;
using Orleans;

namespace GrainInterfaces
{
	public interface IPrinter: IGrainWithIntegerKey
    {
        Task PrintAverage(AverageTemperature data);
        Task ThresholdExceeded(ThresholdExceeded msg);
	    Task ValueNormalized(ValueNormalized msg);
    }
}
