namespace MessengerMAUI;

public partial class LogInPage : ContentPage
{
	public LogInPage()
	{
		InitializeComponent();
		if (UserData.HaveUserSavedData == "True")
		{
            if (ServerUserLoginChecker(UserData.UserSavedLogin, UserData.UserSavedPassword) == true)
			{

			}
			else
			{
				ErrorRectangle.IsVisible=true;
				ErrorCantLogin.IsVisible=true;
                LoginTextBox.Text = UserData.UserLogin;
                PasswordTextBox.Text = UserData.UserLogin;
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
        //Начиная с этой строки, код, который принадлежит этой функции, является ТЕСТОВЫМ функционалом
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
				Shell.Current.GoToAsync("MainPage");
			}
			else
			{
				ErrorCantLogin.Text = "Неправильные уч. данные!";
				ErrorRectangle.IsVisible = true;
                ErrorCantLogin.IsVisible = true;
            }
		}
	}
}