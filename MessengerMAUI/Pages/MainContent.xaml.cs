using System.Net.Sockets;
using System.Text;
using MessengerMAUI.Objects;

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
    }

    User user = new User();
    void initProfile()
    {
        user.loadData();

        //Initials.Text = inicialsGenerator(user.FullName);
        //TODO: �������� ��������� ����� �������
    }

    string inicialsGenerator(string Name) //����������� ���������� ����������� �� ����� �����������
    {
        if (Name != null) //TODO:�������������� ���!!! � � PersonCardPattern.xaml.cs
        {
            string inicials = Name[0].ToString();//�������� ������ ������ �� ������� �����������

            int i = 1;
            while (i <= Name.Length)
            {
                if (Name[i] == ' ')//���� ������ � ������ ����� ������� � ��������
                {
                    inicials += Name[i + 1];//�������� ������ ������� � ������ ����
                    break;
                }
                i++;
            }
            return inicials; //���������� ��������� ����� ������
        }
        else //���� ��� ������ ������, ������� ������
        {
            return "ERR";
        }
    }

    void openChat(string PersonName = "")//����� ����
    {
        ChatProcessor chat = new ChatProcessor(PersonName) { Margin = new Thickness(10, 0, 0, 0) };
        ContentGrid.Clear();
        ContentGrid.Add(chat, 2);
    }

    void initchatcards() //�������� �������� �����������
    {
        DownloadPeoples();
        ChatListCostructure chatList = new ChatListCostructure(this);
        //TODO: !!�������� ���������� ������� �� �������� �����������!!
        //TODO: !�������� ����� �� ������� ���� ��������� ��������! DONE 50%
        ListOfChats.Clear();
        ListOfChats.Add(chatList);

        //openChat("�������� ����");
    }

    public List<People> peoples = new List<People>();

    void DownloadPeoples()
    {
        People people = new People(); //Simulator event
        people.login = "IliaK";
        people.name = "������ ����";
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
        people.name = "�������� ����";
        people.lastMessage = "�! �����!";
        people.friendStatus = true;
        people.onlineStatus = false;
        people.lastMessageTime = "9:25";
        people.haveChat = true;
        people.IsSendLastMessage = false;
        people.IsReadLastMessage = false;
        peoples.Add(people);

        people = new People(); //Simulator event
        people.login = "DmitryK";
        people.name = "������� �������";
        people.lastMessage = "�� ������ ������?";
        people.friendStatus = true;
        people.onlineStatus = true;
        people.lastMessageTime = "16:25";
        people.haveChat = true;
        people.IsSendLastMessage = false;
        people.IsReadLastMessage = true;
        peoples.Add(people);

        people = new People(); //Simulator event
        people.login = "TerehovS";
        people.name = "������� �����";
        people.lastMessage = "����, �� ��������?";
        people.friendStatus = true;
        people.onlineStatus = false;
        people.lastMessageTime = "20:10";
        people.haveChat = true;
        people.IsSendLastMessage = true;
        people.IsReadLastMessage = false;
        peoples.Add(people);

        people = new People(); //Simulator event
        people.login = "MarinaD";
        people.name = "����� ������";
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

        //TODO: �������� �������� ������ �� ������
        //TODO: !�������� �������!
    }
}

