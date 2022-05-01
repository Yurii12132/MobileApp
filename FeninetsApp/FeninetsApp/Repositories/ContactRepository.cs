using FeninetsApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FeninetsApp.Repositories
{
    public class ContactRepository
    {
        SQLiteAsyncConnection database;

        public ContactRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<Contact>();
        }
        public async Task<List<Contact>> GetItemsAsync()
        {
            return await database.Table<Contact>().ToListAsync();

        }
        public async Task<Contact> GetItemAsync(int id)
        {
            return await database.GetAsync<Contact>(id);
        }
        public async Task<int> DeleteItemAsync(Contact item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(Contact item)
        {
            if (item.Id != 0)
            {
                await database.UpdateAsync(item);
                return item.Id;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }
    }
}
