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
        ToDoModel todo;
        [ObservableProperty]
        ToDoModel toSaveOnDB;
        
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
        [ObservableProperty]
        string text;
    

     
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Todo = query["Todo"] as ToDoModel;
        }


        [RelayCommand]
        private async Task DeleteOnDb(ToDoModel todo)
        {
            var modelToDelete = await _dbConnection.GetItemAsync(Todo.Id);
            //if(modelToDelete != null)
            {
                
                await _dbConnection.DeleteItemAsync(modelToDelete);
                ToDolist = await _dbConnection.GetItemsAsync();
                BackCommand.Execute(null);

            }
            
        }
        
        [RelayCommand]
        Task Back() => Shell.Current.GoToAsync("..");

    }


}
