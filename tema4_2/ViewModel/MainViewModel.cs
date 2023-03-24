using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using tema4_2.Models;
using tema4_2.Services;
using tema4_2.View;
using System.Collections.ObjectModel;

namespace tema4_2.ViewModel
{
    public partial class MainViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        ObservableCollection<ToDoModel> toDolist;

        [ObservableProperty]
        ToDoModel toSaveOnDB;

        private readonly DbConnection _dbConnection;

        public MainViewModel(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            ToDolist = new ObservableCollection<ToDoModel>();
            ToSaveOnDB = new ToDoModel();
            GetInitalDataCommand.Execute(null);
        }

        [RelayCommand]
        private async void GetInitalData()
        {
            var toDoListBase = await _dbConnection.GetItemsAsync();
            ToDolist = new ObservableCollection<ToDoModel>(toDoListBase); 
        }

        [RelayCommand]
        private async void GoToAddItem()
        {
            await Shell.Current.GoToAsync(nameof(AddItem));
        }

        [RelayCommand]
        private async void GoToMoreInfo(ToDoModel todo)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Todo", todo }
            };

            await Shell.Current.GoToAsync($"{nameof(EditItem)}", navigationParameter);
        }

        [RelayCommand]
        public async Task DeleteOnDb(ToDoModel todo)
        {
            ToDolist.Remove(todo);
            await _dbConnection.DeleteItemAsync(todo);
        }

        [RelayCommand]
        private async void SaveOnDb()
        {
            if (ToSaveOnDB.Name == null)
                return;

            ToDolist.Add(ToSaveOnDB);
            await _dbConnection.SaveItemAsync(ToSaveOnDB);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("IdUser"))
            {
                var id = (int)query["IdUser"];

                var todoItem = ToDolist.Where(x => x.Id == id).FirstOrDefault();

                ToDolist.Remove(todoItem);
            }
        }
    }
}
