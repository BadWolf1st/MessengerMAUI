using MessengerMAUI.Objects;
using System.Net.Sockets;

namespace MessengerMAUI;

public partial class LoginContent : ContentView
{
    public TcpClient client = new TcpClient();

    MainPage Page;

    public LoginContent(MainPage page)
    {
        InitializeComponent();
        client = page.client;
        Page = page;
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
        //if (AcceptAuthorization == "1")
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}

        return true;
    }

    private void LogInButton_Clicked(object sender, EventArgs e)
    {
        NetworkStream stream = client.GetStream();

        getUserData();

        //byte[] data = Encoding.Unicode.GetBytes(UserLogin + " " + UserPassword);
        //stream.Write(data, 0, data.Length);

        //data = new byte[256]; // буфер для получаемых данных
        //StringBuilder builder = new StringBuilder();
        //int bytes = 0;
        //do
        //{
        //    bytes = stream.Read(data, 0, data.Length);
        //    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
        //}
        //while (stream.DataAvailable);
        //
        //AcceptAuthorization = builder.ToString();

        if (ServerUserLoginChecker())
        {
            // TODO: сделать сохранение уч. данных

            ErrorCantLogin.IsVisible = false;
            ErrorRectangle.IsVisible = false;
            Page.user.Login = UserLogin;
            Page.user.Password = UserPassword;
            Page.user.FullName = UserLogin;
            stream.Close();
            Page.pageChanger("Main");
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
        if (ShowPasswordSwitch.IsToggled)
        {
            PasswordTextBox.IsPassword = false;
        }
        else
        {
            PasswordTextBox.IsPassword = true;
        }
    }
}