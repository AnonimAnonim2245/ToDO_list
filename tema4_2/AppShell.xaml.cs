using tema4_2.View;

namespace tema4_2;

public partial class AppShell : Shell
{
	public AppShell()
    {
		InitializeComponent();
        
        Routing.RegisterRoute(nameof(EditItems), typeof(EditItems));
        Routing.RegisterRoute(nameof(AddItem), typeof(AddItem));
        
    }
}
