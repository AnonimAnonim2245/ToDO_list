using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using tema4_2.Models;
using tema4_2.Services;
using tema4_2.View;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Messaging;
using tema4_2.Messages;

namespace tema4_2.ViewModel
{
    //[QueryProperty("Text", "Text")]
    public partial class AddViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        List<ToDoModel> toDolist;

        [ObservableProperty]
        ToDoModel todo;

        [ObservableProperty]
        ToDoModel toSaveOnDB;

        private readonly DbConnection _dbConnection;

        public AddViewModel(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            toDolist = new List<ToDoModel>();
            toSaveOnDB = new ToDoModel();
            //Todo.Ok = 0;
            GetInitalDataCommand.Execute(null);
        }

        [RelayCommand]
        private async void GetInitalData()
        {
            ToDolist = await _dbConnection.GetItemsAsync();
        }
        [ObservableProperty]
        ObservableCollection<string> items;
        [ObservableProperty]
        string text;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Todo = query["Todo"] as ToDoModel;
            Todo.Ok = 0;
        }

        [RelayCommand]
        private async Task SaveOnDb()
        {
            if (ToSaveOnDB.Name == null)
                return;
            // ToDolist.Add(ToSaveOnDB);
            await _dbConnection.SaveItemAsync(ToSaveOnDB);
            Todo.Ok = 1;
            BackCommand.Execute(null);
            /* (ToSaveOnDB.Name != null)
            {
                
                ToDolist = await _dbConnection.GetItemsAsync();
                await Shell.Current.GoToAsync("..");
            }*/
        }

        

        [RelayCommand]

         private async Task Back()
         {
            //var query = new Dictionary<string, object>();
            if (Todo.Ok == 1)
            {
                Console.WriteLine("3");
                var parameters = new Dictionary<string, object>()
             {
                 {"NameUser",ToSaveOnDB }
                 //{"NameUser2",Todo.Id}
             };
                await Shell.Current.GoToAsync("..", parameters);
            }
            else
            {
                var parameters = new Dictionary<string, object>()
             {
                 {"NameUser",null }
                 //{"NameUser2",Todo.Id}
             };
                await Shell.Current.GoToAsync("..", parameters);
                

            }




            // await Shell.Current.GoToAsync("..");

        }

    }
}
