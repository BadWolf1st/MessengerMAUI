using Microsoft.Maui.Dispatching;

namespace MessengerMAUI;

public partial class LogInPage : ContentPage
{
	public LogInPage()
	{
		InitializeComponent();
		//if (UserData.HaveUserSavedData == "True")
		//{
  //          if (ServerUserLoginChecker(UserData.UserSavedLogin, UserData.UserSavedPassword) == true)// REFACTOR: Ïðåäåëàòü, ò.ê. íå âîçìîæíî ñîõðàíÿòü äàííûå â .resx
  //          {
  //              LoginTextBox.Text = UserData.UserSavedLogin;
  //              PasswordTextBox.Text = UserData.UserSavedPassword;
		//		getUserData();
  //              Shell.Current.GoToAsync("MainPage");
  //              ErrorCantLogin.IsVisible = false;
  //              ErrorRectangle.IsVisible = false;
  //          }
		//	else
		//	{
		//		ErrorRectangle.IsVisible=true;
		//		ErrorCantLogin.IsVisible=true;
  //              LoginTextBox.Text = UserData.UserSavedLogin;
  //              PasswordTextBox.Text = UserData.UserSavedPassword;
  //          }
		//}
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
        // HACK: Íà÷èíàÿ ñ ýòîé ñòðîêè, êîä, êîòîðûé ïðèíàäëåæèò ýòîé ôóíêöèè, ÿâëÿåòñÿ ÒÅÑÒÎÂÛÌ ôóíêöèîíàëîì 
        if (Login == "Ðàñêóòèí Ñåðãåé" && Password == "12345678")
        {
            User user = new User();
			user.Login=Login;
			user.Password=Password;
			user.FullName = Login;
			user.saveData();

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
				// TODO: ñäåëàòü ñîõðàíåíèå ó÷. äàííûõ
				Shell.Current.GoToAsync("MainPage");
                ErrorCantLogin.IsVisible = false;
                ErrorRectangle.IsVisible = false;
            }
			else
			{
				ErrorCantLogin.Text = "Íåïðàâèëüíûå ó÷. äàííûå!";
				errorMessageRectangle.IsVisible = true;
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