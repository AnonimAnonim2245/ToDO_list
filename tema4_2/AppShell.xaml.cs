using tema4_2.View;

namespace tema4_2;

public partial class AppShell : Shell
{
	public AppShell()
    {
		InitializeComponent();
        
        Routing.RegisterRoute(nameof(EditItem), typeof(EditItem));
        Routing.RegisterRoute(nameof(AddItem), typeof(AddItem));
        
    }
}
