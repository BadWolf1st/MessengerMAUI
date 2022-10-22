using System.Threading;

namespace MessengerMAUI;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        

        openChat();
        //checkFriendButton();//Как её проверять паралельно с работой приложения? Многопаточность?
    }

    void openChat()
    {
        ChatProcessor chat = new ChatProcessor();
        MainGrid.Add(chat, 1);
    }

    //void checkFriendButton()
    //{
    //    while (true) { //Хз как это починить
    //        if (FriendButton.IsPressed == true)
    //        {
    //            FriendButtonBackground.BackgroundColor = Color.Parse("#7E7E7E");
    //        }
    //        else
    //        {
    //            FriendButtonBackground.BackgroundColor = Color.Parse("#161719");
    //        }
    //    }
    //}
    bool FriendListIsOpen = false;
    private void ClickedFriendButton(object sender, EventArgs e)
    {
        if (FriendListIsOpen == true)
        {
            FriendListIsOpen = false;
            FriendButton.Background = Color.Parse("#161719");
        }
        else
        {
            FriendListIsOpen=true;
            FriendButton.Background = Color.Parse("#7E7E7E");
        }
    }

    private void ExitAccount(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}

