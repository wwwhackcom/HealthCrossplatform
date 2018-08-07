using System.Threading.Tasks;
using HealthCrossplatform.Core.Models;

namespace HealthCrossplatform.Core.Services.Interface
{
    public interface IUserService
    {
        Task<PagedResult<User>> GetUsersAsync(string url = null);

        Task<User> GetUserAsync();
    }
}
