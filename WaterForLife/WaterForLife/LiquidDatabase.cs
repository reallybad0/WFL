using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;
namespace WaterForLife
{
    public class LiquidDatabase
    {
        private SQLiteAsyncConnection database;
        public LiquidDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Liquid>().Wait();
            database.CreateTableAsync<LiquidRecord>().Wait();
        }
        public Task<List<T>> GetItems<T>() where T : ATable, new()
        {
            return database.Table<T>().ToListAsync();
        }
        public Task<int> SaveItems<T>(T item) where T : ATable, new()
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

    }
}
