using tema4_2.ViewModel;

namespace tema4_2.View;

public partial class AddItem: ContentPage
{
   
    public AddItem(AddViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}