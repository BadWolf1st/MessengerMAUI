using Microsoft.Maui.Dispatching;

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
				Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
			else
			{
				errorMessageRectangle.IsVisible=true;
				ErrorCantLogin.IsVisible=true;
                LoginTextBox.Text = UserData.UserLogin;
                PasswordTextBox.Text = UserData.UserLogin;
            }
		}
	}
	Shell shell;
	public void setShell(Shell workShell)
	{
		shell = workShell;
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
                ErrorCantLogin.Text = "Неправильные уч. данные!";
                errorMessageRectangle.IsVisible = true;
                ErrorCantLogin.IsVisible = false;


				//Shell.Current.GoToAsync($"//{nameof(MainPage)}");
				//Shell.Current.GoToAsync($"//{nameof(MainPage)}");
				//Shell.Current.
				Shell.Current.Title = "Messenger";
            }
			else
			{
				ErrorCantLogin.Text = "Неправильные уч. данные!";
				errorMessageRectangle.IsVisible = true;
                ErrorCantLogin.IsVisible = true;
            }
		}
	}
}