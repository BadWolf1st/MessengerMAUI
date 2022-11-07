using MessengerMAUI.Objects;
using System.Net.Sockets;
using System.Text;
namespace MessengerMAUI;

public partial class MainContent : ContentView
{
    public TcpClient client = new TcpClient();
    MainPage Page;

    public MainContent(MainPage page)
    {
        //client = page.client;
        Page = page;
        InitializeComponent();
        initProfile();
        initchatcards();
        ContentGrid.Add(new ContentViews.AdminContent());
    }

    void initProfile()
    {
        //user.loadData();

        //Initials.Text = inicialsGenerator(user.FullName);
        //TODO: Äîáàâèòü îáðàáîòêó öâåòà ïðîôèëÿ
    }

    string inicialsGenerator(string Name) //Êîíñòðóêòîð èíèöèàëëîâ ñîáåñåäíèêà èç èìåíè ñîáåñäåíèêà
    {
        if (Name != null) //TODO:Îïòèìèçèðîâàòü ýòî!!! è â PersonCardPattern.xaml.cs
        {
            string inicials = Name[0].ToString();//Êîïèðóåì ïåðâûé ñèìâîë èç Ôàìèëèè ñîáåñåäíèêà
            int i = 1;
            while (i <= Name.Length)
            {
                if (Name[i] == ' ')//Èùåì ðàçðûâ â ñòðîêå ìåæäó èìåíåíì è ôàìèëèåé
                {
                    inicials += Name[i + 1];//Êîïèðóåì âòîðîé èíèöèàë è ðàíÿåì öèêë
                    break;
                }
                i++;
            }
            return inicials; //Âîçâðàùàåì èíèöèàëëû ââèäå ñòðîêè
        }
        else //Åñëè èìÿ ïðèøëî ïóñòîå, âûâîäèì îøèáêó
        {
            return "ERR";
        }
    }

    public void openChat(string PersonName = "")//Call chat
    {
        //update chatList like Native
        DownloadPeoples();
        chatList.reInitElementNativeOpenChat(PersonName);

        //download chat content here

        //and open chat
        ChatProcessor chat = new ChatProcessor(PersonName) { Margin = new Thickness(10, 0, 0, 0) };
        ContentGrid.Clear();
        ContentGrid.Add(chat, 2);
    }

    void updateChatList() //Method for Server (updating UI chat list)
    {
        DownloadPeoples();
        chatList.reInitElement();
    }

    ChatListCostructure chatList;

    void initchatcards() //create chat cards
    {
        DownloadPeoples();
        chatList = new ChatListCostructure(this);
        //TODO: !Äîáàâèòü âûâîä èç ñåðâåðà âñåõ äîñòóïíûõ êàðòî÷åê! DONE 50%
        ListOfChats.Clear();
        ListOfChats.Add(chatList);
    }

    public List<People> peoples = new List<People>();

    void DownloadPeoples()// Dowloading friends info from Server
    {
        peoples.Clear();
        People people = new People(); //Simulator event
        people.login = "IliaK";
        people.name = "Êîðæîâ Èëüÿ";
        people.lastMessage = "Hi there!";
        people.friendStatus = true;
        people.onlineStatus = true;
        people.lastMessageTime = "19:30";
        people.haveChat = true;
        people.IsSendLastMessage = true;
        people.IsReadLastMessage = true;
        peoples.Add(people);

        people = new People(); //Simulator event
        people.login = "IliaV";
        people.name = "Âèêòîðîâ Èëüÿ";
        people.lastMessage = "Î! Ñåð¸ãà!";
        people.friendStatus = true;
        people.onlineStatus = false;
        people.lastMessageTime = "9:25";
        people.haveChat = true;
        people.IsSendLastMessage = false;
        people.IsReadLastMessage = false;
        peoples.Add(people);

        people = new People(); //Simulator event
        people.login = "DmitryK";
        people.name = "Êóçüìèí Äìèòðèé";
        people.lastMessage = "Ãî ôèçèêó äåëàòü?";
        people.friendStatus = true;
        people.onlineStatus = true;
        people.lastMessageTime = "16:25";
        people.haveChat = true;
        people.IsSendLastMessage = false;
        people.IsReadLastMessage = true;
        peoples.Add(people);

        people = new People(); //Simulator event
        people.login = "TerehovS";
        people.name = "Òåðåõîâ Ñëàâà";
        people.lastMessage = "Ñåð¸ã, íå îòâëåêàþ?";
        people.friendStatus = true;
        people.onlineStatus = false;
        people.lastMessageTime = "20:10";
        people.haveChat = true;
        people.IsSendLastMessage = true;
        people.IsReadLastMessage = false;
        peoples.Add(people);

        people = new People(); //Simulator event
        people.login = "MarinaD";
        people.name = "Äàøêî Ìàðèíà";
        people.lastMessage = "";
        people.friendStatus = false;
        people.onlineStatus = false;
        people.lastMessageTime = "";
        people.haveChat = false;
        people.IsSendLastMessage = false;
        people.IsReadLastMessage = false;
        peoples.Add(people);


        //Event Loading peoples from server
    }

    bool FriendListIsOpen = false;
    private void ClickedFriendButton(object sender, EventArgs e)
    {
        if (FriendListIsOpen == true)
        {
            FriendListIsOpen = false;
            FriendButton.Background = Color.Parse("#161719");
            ContentGrid.Clear();
        }
        else
        {
            FriendListIsOpen = true;
            FriendButton.Background = Color.Parse("#7E7E7E");
            FriendContent content = new FriendContent(this);
            ContentGrid.Clear();
            ContentGrid.Add(content, 2);
        }

        //TODO: Äîáàâèòü îòïðàâêó èâåíòà íà ñåðâåð
        //TODO: !Äîáàâèòü êîíòåíò!
    }
}