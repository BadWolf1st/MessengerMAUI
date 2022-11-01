namespace MessengerMAUI;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        
        initchatcards();
    }

    void openChat(string PersonName="")//Вызов чата
    {
        ChatProcessor chat = new ChatProcessor(PersonName) { Margin = new Thickness(10, 0, 0, 0) };
        MainGrid.Add(chat, 2);
    }

    void initchatcards() //Создание карточек собеседника
    {
        ChatListCostructure chatList = new ChatListCostructure();
        chatList.generateCard("Викторов Илья", "Как настроение?");
        //TODO: Добавить обработчик нажатия по карточке собеседника
        //TODO: Добавить вывод из сервера всех доступных карточек
        ListOfChats.Add(chatList);
    }

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

