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
        ChatListCostructure chatList = new ChatListCostructure();
        chatList.generateCard("Викторов Илья", "Как настроение?");
        //TODO: !!Добавить обработчик нажатия по карточке собеседника!!
        //TODO: !Добавить вывод из сервера всех доступных карточек!
        ListOfChats.Clear();
        ListOfChats.Add(chatList);

        //openChat("Викторов Илья");
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

        //TODO: Добавить отправку ивента на сервер
        //TODO: !Добавить контент!
    }
}