using CL4PTR4P.Services.Common;
using System.Threading.Tasks;

namespace CL4PTR4P.Services.Interfaces
{
    public interface IGroupFinderService
    {
        Task<ServiceResponse> AddListingAsync(ulong userId, string gameName);

        Task FindListingAsync(string gameName);

        Task GetListingsAsync();
    }
}