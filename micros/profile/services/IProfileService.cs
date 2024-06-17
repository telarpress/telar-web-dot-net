using Profile.Models;

namespace Profile.Services
{
    public interface IProfileService
    {
        Task<IEnumerable<UserProfile>> GetAllAsync();
        Task<UserProfile> GetByIdAsync(string id);
        Task CreateAsync(UserProfile profile);
    }
}
