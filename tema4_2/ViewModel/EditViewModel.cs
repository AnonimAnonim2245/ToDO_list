using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using tema4_2.Models;
using tema4_2.Services;
using tema4_2.View;
using System.Collections.ObjectModel;

namespace tema4_2.ViewModel
{
    public partial class EditViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        List<ToDoModel> toDolist;

        [ObservableProperty]
        ToDoModel todo;

        [ObservableProperty]
        ToDoModel toSaveOnDB;

        [ObservableProperty]
        string text;

        private readonly DbConnection _dbConnection;

        public EditViewModel(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            toDolist = new List<ToDoModel>();
            toSaveOnDB = new ToDoModel();
            //toDeleteOnDB = new ToDoModel();
            todo = new ToDoModel();
            GetInitalDataCommand.Execute(null);
        }

        [RelayCommand]
        private async void GetInitalData()
        {
            ToDolist = await _dbConnection.GetItemsAsync();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Todo = query["Todo"] as ToDoModel;
        }


        [RelayCommand]
        private async Task DeleteOnDb()
        {
            await _dbConnection.DeleteItemAsync(Todo);
            BackCommand.Execute(null);
        }

        [RelayCommand]
        async Task Back()
        {
            var prameters = new Dictionary<string, object> 
            { 
                { "IdUser", Todo.Id }
            };

           await Shell.Current.GoToAsync("..", prameters);
        }
    }
}
