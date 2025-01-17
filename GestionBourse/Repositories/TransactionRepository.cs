using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionBourse.Datas;
using GestionBourse.Models;

namespace GestionBourse.Repositories
{
    public class TransactionRepository
    {
        public TransactionRepository() { }

        public async Task Create(Transaction transaction)
        {
            await DataBase.GetConnection().InsertAsync(transaction);
        }

        public async Task<List<Transaction>> GetTransactionsByIdTrader(int idTrader)
        {
            List<Transaction> transactions = await DataBase.GetConnection().Table<Transaction>().Where(t => t.NumTrader == idTrader).ToListAsync();
            return transactions;
        }

        public async Task<List<TransactionTrader>> GetTransactionsForTrader(int traderId)
        {
            var transactions = await DataBase.GetConnection().Table<Transaction>()
                .Where(transac => transac.NumTrader == traderId)
                .ToListAsync();

            var actions = await DataBase.GetConnection().Table<Models.Action>().ToListAsync();

            var query = from t in transactions
                        join a in actions on t.NumAction equals a.IdAction
                        select new TransactionTrader
                        {
                            IdTransaction = t.IdTransaction,
                            NomAction = a.NomAction,
                            Quantite = t.Quantite,
                            PrixAchat = t.PrixAchat
                        };

            return query.ToList();
        }

        public async Task Delete(Transaction transaction)
        {
            await DataBase.GetConnection().DeleteAsync(transaction);
        }

        public async Task Update(Transaction transaction)
        {
            await DataBase.GetConnection().UpdateAsync(transaction);
        }

        public async Task<Transaction> GetTransactionById(int idTransaction)
        {
            return await DataBase.GetConnection().Table<Transaction>().Where(transac => transac.IdTransaction == idTransaction).FirstOrDefaultAsync();
        }
    }
}
