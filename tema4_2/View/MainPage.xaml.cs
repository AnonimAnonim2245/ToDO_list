
using tema4_2.ViewModel;
namespace tema4_2.View;
using tema4_2.Services;

public partial class MainPage : ContentPage
{
	int count = 0;
    private MainViewModel vm;
    public MainPage(DbConnection dbConnection)
	{
		InitializeComponent();
        vm = new MainViewModel(dbConnection);
        BindingContext = vm;
    }
    

}

