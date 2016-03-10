using System.Threading.Tasks;
using Common.Messages;
using Common.Services;
using Orleans;

namespace GrainInterfaces
{
    public interface IProcessor : IGrainWithIntegerKey
    {
        Task Init(IPrinter printerGrain);
        Task AddTemperature(DeviceTemperature data);
    }
}
