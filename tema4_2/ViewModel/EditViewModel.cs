using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using tema4_2.Models;
using tema4_2.Services;
using tema4_2.View;
using System.Collections.ObjectModel;

namespace tema4_2.ViewModel
{
    [QueryProperty("Text", "Text")]

    public partial class EditViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        List<ToDoModel> toDolist;

        [ObservableProperty]
        ToDoModel todo = new();
        [ObservableProperty]
        ToDoModel toSaveOnDB;
        [ObservableProperty]
        ToDoModel toDeleteOnDB;
        private readonly DbConnection _dbConnection;


        public EditViewModel(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            toDolist = new List<ToDoModel>();
            toSaveOnDB = new ToDoModel();
            toDeleteOnDB = new ToDoModel();
            GetInitalDataCommand.Execute(null);
        }

        [RelayCommand]
        private async void GetInitalData()
        {
            ToDolist = await _dbConnection.GetItemsAsync();
        }
        [ObservableProperty]
        string text;
    

     
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Todo = query["Todo"] as ToDoModel;
        }


        [RelayCommand]
        private async void DeleteOnDb()
        {
            await _dbConnection.DeleteItemAsync(ToSaveOnDB);
            ToDolist = await _dbConnection.GetItemsAsync();
            await Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        Task Back() => Shell.Current.GoToAsync("..");

    }


}
