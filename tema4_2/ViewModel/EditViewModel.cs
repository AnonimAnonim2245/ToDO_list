using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Views;
using tema4_2.Models;
using tema4_2.Services;
using tema4_2.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace tema4_2.ViewModel
{
    [QueryProperty("Text", "Text")]

    public partial class EditViewModel : Popup
    {
        public List<ToDoModel> ToDolist { get; set; }

        public ICommand CloseCommand { get; set; }
        public ObservableCollection<string> Items { get; set; }
        //[ObservableProperty]
        private ToDoModel _todo;
        public ToDoModel Todo
        {
            get { return _todo; }
            set
            {
                if (_todo != value)
                {
                    _todo = value;
                    OnPropertyChanged(nameof(Todo));
                }
            }
        }

        public ToDoModel ToSaveOnDb {get; set; }

        public string Text { get; set; }

        //private readonly DbConnection _dbConnection;


        public EditViewModel()
        {
            Items = new ObservableCollection<string>();

        }




        // [RelayCommand]
        // private async Task DeleteOnDb()
        //{
        /*var modelToDelete = await _dbConnection.GetItemAsync(Todo.Id);
        //if(modelToDelete != null)
        {

            await _dbConnection.DeleteItemAsync(modelToDelete);
            ToDolist = await _dbConnection.GetItemsAsync();
            BackCommand.Execute(null);

        }

        Todo.Ok = 1;
        //await _dbConnection.DeleteItemAsync(Todo);

        BackCommand.Execute(null);

    }
*/
        /*
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
                Close();
            }
                
           


        }
        */
        [RelayCommand]

        void Delete(string s)
        {
            Console.WriteLine('3');

            char[] b = new char[s.Length];
            StringReader sr = new StringReader(s);
            sr.Read(b, 0, 13);
            Console.WriteLine(b);
            if (Items.Contains(s))
            {
                Items.Remove(s);
            }
            Close();
        }
        [RelayCommand]
        void Add()
        {
            /*if (string.IsNullOrWhiteSpace(Text))
                return;
            Items.Add(Text);
            Text = string.Empty;*/
            CloseCommand = new Command(() =>
            {
                // Logic to close the pop-up screen
            });
        }
        /* private void CancelButton_Clicked(object sender, EventArgs e)
         {
             Close();
         }

         private void SaveButton_Clicked(object sender, EventArgs e)
         {


             Close();
         }*/
        //Task Back() => Shell.Current.GoToAsync("..");

    }


}
