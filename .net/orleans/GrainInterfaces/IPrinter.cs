using System.Threading.Tasks;
using Orleans;

namespace GrainInterfaces
{
	public interface IPrinter: IGrainWithIntegerKey
    {
        Task<string> SayHello();
    }
}
