using tema4_2.Models;
using SQLite;

namespace tema4_2.Services;

public class DbConnection
{
    SQLiteAsyncConnection Database;

    public const SQLite.SQLiteOpenFlags Flags =
      // open the database in read/write mode
      SQLite.SQLiteOpenFlags.ReadWrite |
      // create the database if it doesn't exist
      SQLite.SQLiteOpenFlags.Create |
      // enable multi-threaded database access
      SQLite.SQLiteOpenFlags.SharedCache;

    public DbConnection()
    {
    }

    async Task Init()
    {
        if (Database is not null)
            return;

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "ToDoDb.db");

        try
        {
            Database = new SQLiteAsyncConnection(databasePath, Flags);
        }
        catch (Exception ex)
        {

        }

        await Database.CreateTableAsync<ToDoModel>();
    }

    public async Task<List<ToDoModel>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<ToDoModel>().ToListAsync();
    }

    public async Task<ToDoModel> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<ToDoModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(ToDoModel item)
    {
        await Init();
        return await Database.InsertAsync(item);
    }

    public async Task<int> UpdateItemAsync(ToDoModel item)
    {
        await Init();
        return await Database.UpdateAsync(item);
    }

    public async Task<int> SaveAllItemAsync(List<ToDoModel> items)
    {
        await Init();
        return await Database.InsertAllAsync(items);
    }

    public async Task<int> DeleteItemAsync(ToDoModel item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }

    public async Task<int> DeleteAllItemsAsync()
    {
        await Init();
        return await Database.DeleteAllAsync<ToDoModel>();
    }
}
