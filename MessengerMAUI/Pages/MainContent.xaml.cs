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
        Page = page;
        client = page.client;
        InitializeComponent();
        initProfile();
        //initchatcards();
        ContentGrid.Add(new ContentViews.AdminContent());
        //DownloadFriends();
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
        DownloadFriends();
        chatList.reInitElementNativeOpenChat(PersonName);

        //download chat content here

        //and open chat
        ChatProcessor chat = new ChatProcessor(PersonName) { Margin = new Thickness(10, 0, 0, 0) };
        ContentGrid.Clear();
        ContentGrid.Add(chat, 2);
    }

    void updateChatList() //Method for Server (updating UI chat list)
    {
        //DownloadFriends();
        chatList.reInitElement();
    }

    ChatListCostructure chatList;

    void initchatcards() //create chat cards
    {
        DownloadFriends();
        chatList = new ChatListCostructure(this);
        //TODO: !Äîáàâèòü âûâîä èç ñåðâåðà âñåõ äîñòóïíûõ êàðòî÷åê! DONE 50%
        ListOfChats.Clear();
        ListOfChats.Add(chatList);
    }

    public List<Friend> friends = new List<Friend>();

    void DownloadFriends()// Dowloading friends info from Server
    {
        Friend friend = new Friend();
        NetworkStream stream = client.GetStream();
        byte[] SendRequest = Encoding.Unicode.GetBytes("3");
        stream.Write(SendRequest, 0, SendRequest.Length);
        string DataPeople = null;
        friends.Clear();
        while (true)
        {
            byte[] data = new byte[1024];// буфер для получаемых данных

            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);

            DataPeople = builder.ToString();
            if (DataPeople == "1")
            {
                break;
            }
            string[] DAta = DataPeople.Split(' ');
            string id = DAta[0];
            string Nickname = DAta[1];
            string OnlineStatus = DAta[2];
            friend.id = id;
            friend.name = Nickname;
            if (OnlineStatus == "Offline")
            {
                friend.onlineStatus = true;
            }
            else
            {
                friend.onlineStatus = false;
            }
            //people.onlineStatus = OnlineStatus;
            friends.Add(friend);
            friend = new Friend();
        }


        //peoples.Clear();

        //people.login = "IliaK";
        //people.name = "Коржов Илья";
        //people.lastMessage = "Hi there!";
        //people.friendStatus = true;
        //people.onlineStatus = true;
        //people.lastMessageTime = "19:30";
        //people.haveChat = true;
        //people.IsSendLastMessage = true;
        //people.IsReadLastMessage = true;
        //peoples.Add(people);

        //people = new People(); //Simulator event
        //people.login = "IliaV";
        //people.name = "Викторов Илья";
        //people.lastMessage = "Серый, где тот метод?";
        //people.friendStatus = true;
        //people.onlineStatus = false;
        //people.lastMessageTime = "9:25";
        //people.haveChat = true;
        //people.IsSendLastMessage = false;
        //people.IsReadLastMessage = false;
        //peoples.Add(people);

        //people = new People(); //Simulator event
        //people.login = "DmitryK";
        //people.name = "Кузьмин Дмитрий";
        //people.lastMessage = "Бро, как дела?";
        //people.friendStatus = true;
        //people.onlineStatus = true;
        //people.lastMessageTime = "16:25";
        //people.haveChat = true;
        //people.IsSendLastMessage = false;
        //people.IsReadLastMessage = true;
        //peoples.Add(people);

        //people = new People(); //Simulator event
        //people.login = "TerehovS";
        //people.name = "Терехов Слава";
        //people.lastMessage = "Привет, занят?";
        //people.friendStatus = true;
        //people.onlineStatus = false;
        //people.lastMessageTime = "20:10";
        //people.haveChat = true;
        //people.IsSendLastMessage = true;
        //people.IsReadLastMessage = false;
        //peoples.Add(people);

        //people = new People(); //Simulator event
        //people.login = "MarinaD";
        //people.name = "Дашко Марина";
        //people.lastMessage = "";
        //people.friendStatus = false;
        //people.onlineStatus = false;
        //people.lastMessageTime = "";
        //people.haveChat = false;
        //people.IsSendLastMessage = false;
        //people.IsReadLastMessage = false;
        //peoples.Add(people);


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