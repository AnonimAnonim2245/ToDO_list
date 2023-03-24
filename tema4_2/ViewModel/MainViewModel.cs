using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using tema4_2.Models;
using tema4_2.Services;
using tema4_2.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace tema4_2.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        List<ToDoModel> toDolist;

        [ObservableProperty]
        ToDoModel todo;

        [ObservableProperty]
        ToDoModel toSaveOnDB;
        [ObservableProperty]
        ToDoModel toDeleteOnDB;

        private readonly DbConnection _dbConnection;
        private readonly ObservableCollection<ToDoModel> models;
        //public ICommand DeleteCommand { get; }

        public MainViewModel(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            toDolist = new List<ToDoModel>();
            toSaveOnDB = new ToDoModel();
            todo = new ToDoModel();
            //models = new ObservableCollection<ToDoModel>();
            //DeleteCommand = new AsyncRelayCommand(DeleteModelAsync);
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

        [RelayCommand]

        private async void GoToBasicNavigation()
        {
            await Shell.Current.GoToAsync(nameof(AddItem));
        }
        partial void OnTodoChanged(ToDoModel value)
        {
            if (value == null) return;
            GoToMoreInfo();
        }
        [RelayCommand]
        private async void GoToMoreInfo()
        {
            var navigationParameter = new Dictionary<string, object>
                {
            { "Todo", Todo }
                };

            Todo = null;

            await Shell.Current.GoToAsync(nameof(EditItem), navigationParameter);
        }
        [RelayCommand]
        public async Task DeleteOnDb(ToDoModel todo)
        {
            
            var modelToDelete = await _dbConnection.GetItemAsync(todo.Id);
            
           // if (modelToDelete != null)
            {
                await _dbConnection.DeleteItemAsync(modelToDelete);
                //models.Remove(modelToDelete
                ToDolist = await _dbConnection.GetItemsAsync();
            }
        }
        [RelayCommand]
        private async void SaveOnDb()
        {

            await _dbConnection.SaveItemAsync(ToSaveOnDB);
            if (ToSaveOnDB.Name != null)
            {
                ToDolist = await _dbConnection.GetItemsAsync();
            }
           
        }
        /*[RelayCommand]
        private async void DeleteOnDb(string Text)
        {
            await _dbConnection.DeleteItemAsync(Todo => Todo.Id == Id);
            ToDolist = await _dbConnection.GetItemsAsync();
        }
        */
        [RelayCommand]
        private async void MoveToANewTab1()
        {
            await Shell.Current.GoToAsync(nameof(AddItem));
        }
    }
    
}
