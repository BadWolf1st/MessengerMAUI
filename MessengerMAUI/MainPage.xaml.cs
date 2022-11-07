using MessengerMAUI.Objects;
using System.Net.Sockets;
namespace MessengerMAUI;
public partial class MainPage : ContentPage
{
    public TcpClient client = new TcpClient(address, port);
    const int port = 8888;
    const string address = "78.107.255.193";
    //const string address = "172.20.10.7";

    public User user = new User();

    public MainPage()
    {
        InitializeComponent();

        initFirstLogin();

    }

    void initFirstLogin()
    {
        LoginContent loginContent = new LoginContent(this);
        ContentMainView.Add(loginContent);
    }

    public void pageChanger(string NameOfPage)
    {
        if (NameOfPage == "Main")
        {
            MainContent Content = new MainContent(this);
            ContentMainView.Add(Content);
        }
        else if (NameOfPage == "Login")
        {
            LoginContent Content = new LoginContent(this);
            ContentMainView.Add(Content);
        }
    }
}

