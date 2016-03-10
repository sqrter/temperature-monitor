using System.Threading.Tasks;
using Orleans;

namespace GrainInterfaces
{
    public interface IDevice : IGrainWithIntegerKey
    {
        Task Init(IProcessor processor);
    }
}
