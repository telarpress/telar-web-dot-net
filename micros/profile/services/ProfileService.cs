using MongoDB.Driver;
using Profile.Database;
using Profile.Models;
using MongoDB.Bson;

namespace Profile.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IMongoCollection<UserProfile> _profiles;

        public ProfileService(ProfileContext context)
        {
            _profiles = context.Profiles;
        }

        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            return await _profiles.Find(_ => true).ToListAsync();
        }

        public async Task<UserProfile> GetByIdAsync(string id)
        {
            return await _profiles.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(UserProfile profile)
        {
            if (profile.Id == null)
            {
                profile.Id = ObjectId.GenerateNewId().ToString();
            }
            await _profiles.InsertOneAsync(profile);
        }
    }
}
