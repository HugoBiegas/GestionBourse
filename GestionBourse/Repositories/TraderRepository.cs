using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionBourse.Datas;
using GestionBourse.Models;

namespace GestionBourse.Repositories
{
    public class TraderRepository
    {
        public TraderRepository() { }

        public void Create(Trader trader)
        {
            DataBase.GetConnection().InsertAsync(trader);
        }

        public async Task<List<Trader>> GetTraders()
        {
            return await DataBase.GetConnection().Table<Trader>().ToListAsync();
        }

        public async Task<List<Trader>> GetTraderById(int idTrader)
        {
            return await DataBase.GetConnection().Table<Trader>().Where(trader => trader.IdTrader == idTrader).ToListAsync();
        }
    }

}
