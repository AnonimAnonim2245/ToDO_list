using tema4_2.ViewModel;
namespace tema4_2.View;

public partial class EditItem : ContentPage
{
 
    public EditItem(EditViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
   
}