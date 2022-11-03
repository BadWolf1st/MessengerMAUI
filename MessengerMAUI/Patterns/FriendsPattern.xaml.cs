namespace MessengerMAUI.Patterns;

public partial class FriendsPattern : ContentView
{
    bool IsAddButton = false;
    public FriendsPattern(string Name, bool IsFriend, bool IsOnline = true)
    {
        InitializeComponent();

        FriendNameLabel.Text = Name;
        ActiveStatus(IsOnline);
        NowWithMe(IsFriend);

    }

    public void ActiveStatus(bool IsOnline)
    {
        OnlineStatus.IsVisible = IsOnline;
    }

    public void NowWithMe(bool IsFriend)
    {
        if (IsFriend)
        {
            chatButton.IsVisible = true;
            multiButton.ImageSource = "delete_friend.png";
            IsAddButton = false;
        }
        else
        {
            chatButton.IsVisible = false;
            multiButton.ImageSource = "add_friend.png";
            IsAddButton = true;
        }
    }

    private void multiButton_Clicked(object sender, EventArgs e)
    {
        if (IsAddButton)
        {
            //event Adding friend to list
            //TODO: —делать ивент добавлени€ этого человека в список друзей
        }
        else
        {
            //event delete friend from list
            //TODO: —делать ивент удалени€ этого друга из списка друзей
        }
    }

    private void chatButton_Clicked(object sender, EventArgs e)
    {
        //event Start or Open chat with this people
        //TODO: —делать ивент открыти€ чата с этим другом
    }
}