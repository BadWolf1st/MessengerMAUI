namespace MessengerMAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        ContentShell.Content = new LogInPage();
        //start();
    }

	public void start()
	{
		
		ContentShell.Content = new MainPage();
		Title = "Messenger";
	}
}
