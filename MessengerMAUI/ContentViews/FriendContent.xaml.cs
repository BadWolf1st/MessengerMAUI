using MessengerMAUI.Patterns;
using System.Net.Sockets;
using System.Text;

namespace MessengerMAUI;

public partial class FriendContent : ContentView
{
    MainContent main;
    public FriendContent(MainContent mainContent)
    {
        InitializeComponent();
        main = mainContent;
        initElement();
    }

    void initElement()
    {
        if (peoples.Count > 0)
        {
            int currentPeople = 0;
            while (currentPeople < peoples.Count)
            {
                listOfFriends.AddRowDefinition(new RowDefinition());
                addNewFriendCard(peoples[currentPeople].name, false, currentPeople, peoples[currentPeople].onlineStatus);
                currentPeople++;
            }
            ScrollViewList.Content = listOfFriends;
        }
    }

    public void reInitElement()
    {
        listOfFriends.Clear();
        initElement();
    }

    public void addNewFriendCard(string name, bool IsFriend, int numOfRow, bool IsOnline = true)
    {
        listOfFriends.Add(new FriendsPattern(name, IsFriend, IsOnline), 0, numOfRow);
    }
    
    List<Objects.People> peoples = new List<Objects.People>();

    private void SearchButton_Clicked(object sender, EventArgs e)
    {
        string search = SearchLineBox.Text;

        //Send event to server (search this people in all users)
        //TODO: create a method on server and create here sending Say to server

        //event download from server
        Objects.People people = new Objects.People();
        NetworkStream stream = main.client.GetStream();
        byte[] SendRequest = Encoding.Unicode.GetBytes("3");
        stream.Write(SendRequest, 0, SendRequest.Length);

        SendRequest = Encoding.Unicode.GetBytes(search);
        stream.Write(SendRequest, 0, SendRequest.Length);

        string DataPeople = null;
        peoples.Clear();
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
            if (DataPeople == "0")
            {
                ///Need to display a message that the user is not found
                ///Необходимо вывести сообщение о том, что пользователь не найден
                break;
            }
            if (DataPeople == "1")
            {
                break;
            }
            string[] DAta = DataPeople.Split(' ');
            string id = DAta[0];
            string Nickname = DAta[1];
            string OnlineStatus = DAta[2];
            people.id = id;
            people.name = Nickname;
            if (OnlineStatus == "Offline")
            {
                people.onlineStatus = true;
            }
            else
            {
                people.onlineStatus = false;
            }
            //people.onlineStatus = OnlineStatus;
            peoples.Add(people);
            people = new Objects.People();
        }


        //event draw get content
        reInitElement();

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
}