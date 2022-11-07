namespace MessengerMAUI.ContentViews;

public partial class AdminContent : ContentView
{
	public AdminContent()
	{
		InitializeComponent();
	}

	private void AddButton_Clicked(object sender, EventArgs e)
	{
		AddForm.IsVisible = true;
		AddButton.BackgroundColor = Color.Parse("#696969");
        DeleteForm.IsVisible = false;
        DeleteButton.BackgroundColor = Color.Parse("#303030");
	}

    private void DeleteButton_Clicked(object sender, EventArgs e)
	{
		DeleteForm.IsVisible = true;
        DeleteButton.BackgroundColor = Color.Parse("#696969");
        AddForm.IsVisible = false;
        AddButton.BackgroundColor = Color.Parse("#303030");
	}
}