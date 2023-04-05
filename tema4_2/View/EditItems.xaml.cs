//using AndroidX.Lifecycle;
using tema4_2.ViewModel;
namespace tema4_2.View;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using tema4_2.Models;
using tema4_2.Services;
public partial class EditItems : Popup
{
   private EditViewModel vm;
    //private readonly DbConnection _dbConnection;
    private ToDoModel _todo;
    private ObservableCollection <string> items;

    public ObservableCollection<string> Items
    {
        get
        {
            return items;
        }
        set
        {
            items = value;
        }
    }
    // public List<string> Items { get; set; }
    public EditItems(ToDoModel todo)
    {
        InitializeComponent();

        _todo = todo;
        myTodo.Text = _todo.Name;
        Items = new ObservableCollection<string>();

    }


    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        Console.WriteLine(sender);

        Close();
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        
        /*OccasionModel occasion = new OccasionModel
        {
            Date = OccasionDate.Date,
            Occasion = OccasionType.SelectedItem.ToString(),
            Notes = OccasionNotes.Text
        };
        
        Close(occasion);*/
        string s = myTodo.Text;
        Console.WriteLine(s);
        
        
            Console.WriteLine(s);
            Items.Remove(myTodo.Text);
        
        Close();

    }

}