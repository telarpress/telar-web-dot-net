using Actions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Actions.Services
{
    public interface IActionService
    {
        Task<IEnumerable<Actions.Models.Action>> GetAll();
        Task<Actions.Models.Action?> GetById(string id);
        Task Create(Actions.Models.Action action);
        Task Update(string id, Actions.Models.Action action);
        Task Delete(string id);
    }
}
