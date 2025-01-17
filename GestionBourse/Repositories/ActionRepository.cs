using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionBourse.Datas;
using GestionBourse.Models;
using Action = GestionBourse.Models.Action;

namespace GestionBourse.Repositories
{
    public class ActionRepository
    {
        public ActionRepository() { }

        public void Create(Action action)
        {
            DataBase.GetConnection().InsertAsync(action);
        }

        public async Task<List<Action>> GetActionsNonPossedees(int idTrader)
        {
            var allActions = await DataBase.GetConnection().Table<Action>().ToListAsync();

            // Récupérer les IDs des actions possédées par le trader
            var ownedActionIds = DataBase.GetConnection().Table<Transaction>()
                .Where(t => t.NumTrader == idTrader).ToListAsync().Result
                .Select(t => t.NumAction)
                .ToList();

            // Filtrer les actions que le trader ne possède pas
            var actionsNotOwned = allActions
                .Where(a => !ownedActionIds.Contains(a.IdAction))
                .ToList();

            return actionsNotOwned;
        }
    }
}
