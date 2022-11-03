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
        //TODO: Добавить обработку цвета профиля
    }

    string inicialsGenerator(string Name) //Конструктор инициаллов собеседника из имени собесденика
    {
        if (Name != null) //TODO:Оптимизировать это!!! и в PersonCardPattern.xaml.cs
        {
            string inicials = Name[0].ToString();//Копируем первый символ из Фамилии собеседника

            int i = 1;
            while (i <= Name.Length)
            {
                if (Name[i] == ' ')//Ищем разрыв в строке между имененм и фамилией
                {
                    inicials += Name[i + 1];//Копируем второй инициал и раняем цикл
                    break;
                }
                i++;
            }
            return inicials; //Возвращаем инициаллы ввиде строки
        }
        else //Если имя пришло пустое, выводим ошибку
        {
            return "ERR";
        }
    }

    void openChat(string PersonName = "")//Вызов чата
    {
        ChatProcessor chat = new ChatProcessor(PersonName) { Margin = new Thickness(10, 0, 0, 0) };
        ContentGrid.Clear();
        ContentGrid.Add(chat, 2);
    }

    void initchatcards() //Создание карточек собеседника
    {
        DownloadPeoples();
        ChatListCostructure chatList = new ChatListCostructure(this);
        //TODO: !!Добавить обработчик нажатия по карточке собеседника!!
        //TODO: !Добавить вывод из сервера всех доступных карточек! DONE 50%
        ListOfChats.Clear();
        ListOfChats.Add(chatList);

        //openChat("Викторов Илья");
    }

    public List<People> peoples = new List<People>();

    void DownloadPeoples()
    {
        People people = new People(); //Simulator event
        people.login = "IliaK";
        people.name = "Коржов Илья";
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
        people.name = "Викторов Илья";
        people.lastMessage = "О! Серёга!";
        people.friendStatus = true;
        people.onlineStatus = false;
        people.lastMessageTime = "9:25";
        people.haveChat = true;
        people.IsSendLastMessage = false;
        people.IsReadLastMessage = false;
        peoples.Add(people);

        people = new People(); //Simulator event
        people.login = "DmitryK";
        people.name = "Кузьмин Дмитрий";
        people.lastMessage = "Го физику делать?";
        people.friendStatus = true;
        people.onlineStatus = true;
        people.lastMessageTime = "16:25";
        people.haveChat = true;
        people.IsSendLastMessage = false;
        people.IsReadLastMessage = true;
        peoples.Add(people);

        people = new People(); //Simulator event
        people.login = "TerehovS";
        people.name = "Терехов Слава";
        people.lastMessage = "Серёг, не отвлекаю?";
        people.friendStatus = true;
        people.onlineStatus = false;
        people.lastMessageTime = "20:10";
        people.haveChat = true;
        people.IsSendLastMessage = true;
        people.IsReadLastMessage = false;
        peoples.Add(people);

        people = new People(); //Simulator event
        people.login = "MarinaD";
        people.name = "Дашко Марина";
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

        //TODO: Добавить отправку ивента на сервер
        //TODO: !Добавить контент!
    }
}

