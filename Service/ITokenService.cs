using FutureCloudContactManager.Models;

namespace FutureCloudContactManager.Service
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
