namespace MessengerMAUI;

public partial class LogInPage : ContentPage
{
	public LogInPage()
	{
		InitializeComponent();
		if (UserData.HaveUserSavedData == "True")
		{
            if (ServerUserLoginChecker(UserData.UserSavedLogin, UserData.UserSavedPassword) == true)// REFACTOR: Пределать, т.к. не возможно сохранять данные в .resx
            {
                LoginTextBox.Text = UserData.UserSavedLogin;
                PasswordTextBox.Text = UserData.UserSavedPassword;
				getUserData();
                Shell.Current.GoToAsync("MainPage");
                ErrorCantLogin.IsVisible = false;
                ErrorRectangle.IsVisible = false;
            }
			else
			{
				ErrorRectangle.IsVisible=true;
				ErrorCantLogin.IsVisible=true;
                LoginTextBox.Text = UserData.UserSavedLogin;
                PasswordTextBox.Text = UserData.UserSavedPassword;
            }
		}
	}

	public string UserLogin = "";
	public string UserPassword = "";

	public void getUserData()
	{
		UserLogin = LoginTextBox.Text;
		UserPassword = PasswordTextBox.Text;
	}

	bool ServerUserLoginChecker( string Login, string Password)
	{
        // HACK: Начиная с этой строки, код, который принадлежит этой функции, является ТЕСТОВЫМ функционалом 
        if (Login == "Раскутин Сергей" && Password == "12345678")
        {
            return true;
        }
		else
		{
			return false;
		}
	}

	private void LogInButton_Clicked(object sender, EventArgs e)
	{
		getUserData();
		if(UserLogin != null && UserPassword != null)
		{
			if (ServerUserLoginChecker(UserLogin, UserPassword) == true)
			{
				// TODO: сделать сохранение уч. данных
				Shell.Current.GoToAsync("MainPage");
                ErrorCantLogin.IsVisible = false;
                ErrorRectangle.IsVisible = false;
            }
			else
			{
				ErrorCantLogin.Text = "Неправильные уч. данные!";
				ErrorRectangle.IsVisible = true;
                ErrorCantLogin.IsVisible = true;
            }
		}
	}

	private void ShowPasswordSwitch_Toggled(object sender, ToggledEventArgs e)
	{
		if (ShowPasswordSwitch.IsToggled == true)
		{
			PasswordTextBox.IsPassword = false;
		}
		else
		{
			PasswordTextBox.IsPassword = true;
		}
	}
}