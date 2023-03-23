using tema4_2.Models;

namespace tema4_2.Services
{
    public interface IDbConnection
    {
        Task<int> DeleteAllItemsAsync();
        Task<int> DeleteItemAsync(ToDoModel item);
        Task<ToDoModel> GetItemAsync(int id);
        Task<List<ToDoModel>> GetItemsAsync();
        Task<int> SaveAllItemAsync(List<ToDoModel> items);
        Task<int> SaveItemAsync(ToDoModel item);
        Task<int> UpdateItemAsync(ToDoModel item);
    }
}