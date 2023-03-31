using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using tema4_2.Models;
using tema4_2.Services;
using tema4_2.View;
using System.Collections.ObjectModel;

namespace tema4_2.ViewModel
{
    //[QueryProperty("Text", "Text")]

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
            Todo.Ok = 0;
        }


        [RelayCommand]
        private async Task DeleteOnDb()
        {
            /*var modelToDelete = await _dbConnection.GetItemAsync(Todo.Id);
            //if(modelToDelete != null)
            {
                
                await _dbConnection.DeleteItemAsync(modelToDelete);
                ToDolist = await _dbConnection.GetItemsAsync();
                BackCommand.Execute(null);

            }
            */
            Todo.Ok = 1;
            await _dbConnection.DeleteItemAsync(Todo);

            BackCommand.Execute(null);

        }
        
        [RelayCommand]
        async Task Back()
        {
            if(Todo.Ok==1)
            {
                var parameters = new Dictionary<string, object>
            {
                {"IdUser", Todo.Id }
                //{"NameUser3",null}
            };

                await Shell.Current.GoToAsync("..", parameters);
            }
            else
            {              
                await Shell.Current.GoToAsync("..");
            }
                
           


        }
        //Task Back() => Shell.Current.GoToAsync("..");

    }


}
