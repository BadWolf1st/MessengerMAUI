namespace MessengerMAUI;

public partial class ChatListCostructure : ContentView
{
    MainContent main;
    public ChatListCostructure(MainContent content)
    {
        InitializeComponent();
        main = content;
        initElement();
    }

    //List<PersonCardPattern> cards = new();
    //int lastItem = 0;

    public void generateCard(string Name = "", string ThisLastMessage = "", bool haveNewMessage = false, int newMessageCount = 0, bool haveIgnore = false, string time = "12:00", string IconColor = "Deafult", string textColor = "Default", bool pushed = false)
    {
        //Chat.AddRowDefinition(new RowDefinition());
        //cards.Add(new PersonCardPattern(Name, ThisLastMessage, haveNewMessage, newMessageCount, haveIgnore, time,  IconColor, textColor));
        //Chat.Add(cards[lastItem], 0, lastItem);
        //lastItem++;
        Chat.Add(new PersonCardPattern(Name, ThisLastMessage, haveNewMessage, newMessageCount, haveIgnore, time, IconColor, textColor));
    }

    void initElement()
    {
        int currentChat = 0;
        if (main.peoples.Count > 0)
        {
            while (currentChat < main.peoples.Count)
            {
                if (main.peoples[currentChat].friendStatus && main.peoples[currentChat].haveChat)
                {
                    generateCard(main.peoples[currentChat].name, main.peoples[currentChat].lastMessage, main.peoples[currentChat].IsSendLastMessage, 1 /*TODO: добавить колличестов сообщений в объект*/ , main.peoples[currentChat].IsReadLastMessage, main.peoples[currentChat].lastMessageTime);
                }
                currentChat++;
            }
        }
    }
}