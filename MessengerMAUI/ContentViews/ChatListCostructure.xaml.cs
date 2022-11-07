namespace MessengerMAUI;

public partial class ChatListCostructure : ContentView
{
    MainContent main;
    public ChatListCostructure(MainContent content)
    {
        //InitializeComponent();
        main = content;
        //initElement();
    }

    public void generateCard(string Name = "", string ThisLastMessage = "", bool haveNewMessage = false, int newMessageCount = 0, bool haveIgnore = false, string time = "12:00", string IconColor = "Deafult", string textColor = "Default", bool pushed = false)
    {
        Chat.Add(new PersonCardPattern(main, Name, ThisLastMessage, haveNewMessage, newMessageCount, haveIgnore, time, pushed, IconColor, textColor));
    }

    //void initElement(string pushedcard = "")
    //{
    //    int currentChat = 0;
    //    if (main.peoples.Count > 0)
    //    {
    //        if(pushedcard == "")
    //        { 
    //            while (currentChat < main.peoples.Count)
    //            {
    //                if (main.peoples[currentChat].friendStatus && main.peoples[currentChat].haveChat)
    //                {
    //                    generateCard(main.peoples[currentChat].name, main.peoples[currentChat].lastMessage, main.peoples[currentChat].IsSendLastMessage, 1 /*TODO: добавить колличестов сообщений в объект*/ , main.peoples[currentChat].IsReadLastMessage, main.peoples[currentChat].lastMessageTime);
    //                }
    //                currentChat++;
    //            }
    //        }
    //        else
    //        {
    //            while (currentChat < main.peoples.Count)
    //            {
    //                if (main.peoples[currentChat].name == pushedcard)
    //                {
    //                    if (main.peoples[currentChat].friendStatus && main.peoples[currentChat].haveChat)
    //                    {
    //                        generateCard(main.peoples[currentChat].name, main.peoples[currentChat].lastMessage, main.peoples[currentChat].IsSendLastMessage, 1 /*TODO: добавить колличестов сообщений в объект*/ , main.peoples[currentChat].IsReadLastMessage, main.peoples[currentChat].lastMessageTime, "Deafault", "Deafault", true);
    //                    }
    //                }
    //                else
    //                {
    //                    if (main.peoples[currentChat].friendStatus && main.peoples[currentChat].haveChat)
    //                    {
    //                        generateCard(main.peoples[currentChat].name, main.peoples[currentChat].lastMessage, main.peoples[currentChat].IsSendLastMessage, 1 /*TODO: добавить колличестов сообщений в объект*/ , main.peoples[currentChat].IsReadLastMessage, main.peoples[currentChat].lastMessageTime);
    //                    }
    //                }
    //                currentChat++;
    //            }
    //        }
    //    }
    //}

    public void reInitElementNativeOpenChat(string chatOpenedName)
    {
        Chat.Clear();
        //initElement(chatOpenedName);
    }

    public void reInitElement()
    {
        Chat.Clear();
        //initElement();
    }
}