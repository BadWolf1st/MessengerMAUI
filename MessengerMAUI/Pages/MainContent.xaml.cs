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
        ChatListCostructure chatList = new ChatListCostructure();
        chatList.generateCard("�������� ����", "��� ����������?");
        //TODO: !!�������� ���������� ������� �� �������� �����������!!
        //TODO: !�������� ����� �� ������� ���� ��������� ��������!
        ListOfChats.Clear();
        ListOfChats.Add(chatList);

        //openChat("�������� ����");
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

            FriendContent content = new FriendContent();
            ContentGrid.Clear();
            ContentGrid.Add(content, 2);
        }

        //TODO: �������� �������� ������ �� ������
        //TODO: !�������� �������!
    }
}