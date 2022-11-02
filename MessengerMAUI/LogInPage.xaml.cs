using Microsoft.Maui.Dispatching;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace MessengerMAUI;

public partial class LogInPage : ContentPage
{
    public TcpClient client = new TcpClient(address, port);
    const int port = 8888;
    const string address = "78.107.255.193";

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

    public string AcceptAuthorization;
    public string UserLogin = "";
    public string UserPassword = "";

    public void getUserData()
    {
        UserLogin = LoginTextBox.Text;
        UserPassword = PasswordTextBox.Text;
    }

    bool ServerUserLoginChecker()
    {
        // HACK: Íà÷èíàÿ ñ ýòîé ñòðîêè, êîä, êîòîðûé ïðèíàäëåæèò ýòîé ôóíêöèè, ÿâëÿåòñÿ ÒÅÑÒÎÂÛÌ ôóíêöèîíàëîì 
        if (AcceptAuthorization == "1")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private async void LogInButton_Clicked(object sender, EventArgs e)
    {

        //const int port = 8888;
        //const string address = "78.107.255.193";
        //client = new TcpClient(address, port);
        NetworkStream stream = client.GetStream();
        getUserData();
        byte[] data = Encoding.Unicode.GetBytes(UserLogin + " " + UserPassword);
        stream.Write(data, 0, data.Length);

        data = new byte[256]; // буфер для получаемых данных
        StringBuilder builder = new StringBuilder();
        int bytes = 0;
        do
        {
            bytes = stream.Read(data, 0, data.Length);
            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
        }
        while (stream.DataAvailable);

        AcceptAuthorization = builder.ToString();





        if (ServerUserLoginChecker() == true)
        {
            // TODO: сделать сохранение уч. данных
            Shell.Current.GoToAsync("MainPage");
            ErrorCantLogin.IsVisible = false;
            ErrorRectangle.IsVisible = false;
            User user = new User();
            user.Login = UserLogin;
            user.Password = UserPassword;
            user.FullName = UserLogin;
            user.saveData();
            //MainPage authorization = new MainPage(client);

        }
        else
        {
            ErrorCantLogin.Text = "Неправильные уч. данные!";
            ErrorRectangle.IsVisible = true;
            ErrorCantLogin.IsVisible = true;
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