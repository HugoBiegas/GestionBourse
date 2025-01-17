using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionBourse.Models;
using GestionBourse.Repositories;
using SQLite;
using Action = GestionBourse.Models.Action;

namespace GestionBourse.Datas
{
    public class DataBase
    {
        private const string DB_NAME = "Bourse.db";
        private static SQLiteAsyncConnection? _connection;

        public DataBase()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            LoadDatas();
        }

        public async void LoadDatas()
        {
            if (_connection == null)
            {
                throw new InvalidOperationException("Database connection is not initialized.");
            }

            await _connection.CreateTableAsync<Trader>();
            await _connection.CreateTableAsync<Action>();
            await _connection.CreateTableAsync<Transaction>();

            int num = await _connection.Table<Trader>().CountAsync();

            if (num == 0)
            {
                TraderRepository traderRepository = new TraderRepository();
                ActionRepository actionRepository = new ActionRepository();
                TransactionRepository transactionRepository = new TransactionRepository();

                // Quelques traders
                Trader trader = new Trader() { NomTrader = "Fortin" };
                traderRepository.Create(trader);
                trader = new Trader() { NomTrader = "Garnier" };
                traderRepository.Create(trader);

                // Quelques actions
                Action action = new Action() { NomAction = "FaceBook" };
                actionRepository.Create(action);
                action = new Action() { NomAction = "Apple" };
                actionRepository.Create(action);
                action = new Action() { NomAction = "Dell" };
                actionRepository.Create(action);
                action = new Action() { NomAction = "IBM" };
                actionRepository.Create(action);
                action = new Action() { NomAction = "Microsoft" };
                actionRepository.Create(action);

                // Quelques transactions pour le trader "Fortin"
                Transaction transaction = new Transaction() { IdTransaction = 1, NumTrader = 1, NumAction = 1, Quantite = 50, PrixAchat = 134.98 };
                await transactionRepository.Create(transaction);
                transaction = new Transaction() { IdTransaction = 2, NumTrader = 1, NumAction = 2, Quantite = 20, PrixAchat = 67.34 };
                await transactionRepository.Create(transaction);
                transaction = new Transaction() { IdTransaction = 3, NumTrader = 2, NumAction = 3, Quantite = 70, PrixAchat = 34.12 };
                await transactionRepository.Create(transaction);
                transaction = new Transaction() { IdTransaction = 4, NumTrader = 2, NumAction = 4, Quantite = 20, PrixAchat = 67.45 };
                await transactionRepository.Create(transaction);
                transaction = new Transaction() { IdTransaction = 5, NumTrader = 2, NumAction = 5, Quantite = 25, PrixAchat = 123.63 };
                await transactionRepository.Create(transaction);
            }
        }

        public static SQLiteAsyncConnection GetConnection()
        {
            if (_connection == null)
            {
                throw new InvalidOperationException("Database connection is not initialized.");
            }
            return _connection;
        }
    }
}
