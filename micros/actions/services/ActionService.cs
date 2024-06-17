using Actions.Database;
using Actions.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Actions.Services
{
    public class ActionService : IActionService
    {
        private readonly IMongoCollection<Actions.Models.Action> _actions;

        public ActionService(ActionContext context)
        {
            _actions = context.Actions;
        }

        public async Task<IEnumerable<Actions.Models.Action>> GetAll() => 
            await _actions.Find(action => true).ToListAsync();

        public async Task<Actions.Models.Action?> GetById(string id) =>
            await _actions.Find(action => action.Id == id).FirstOrDefaultAsync();

        public async Task Create(Actions.Models.Action action)
        {
            if (action.Id == null)
            {
                action.Id = ObjectId.GenerateNewId().ToString();
            }
            await _actions.InsertOneAsync(action);
        }

        public async Task Update(string id, Actions.Models.Action action) =>
            await _actions.ReplaceOneAsync(a => a.Id == id, action);

        public async Task Delete(string id) =>
            await _actions.DeleteOneAsync(action => action.Id == id);
    }
}
