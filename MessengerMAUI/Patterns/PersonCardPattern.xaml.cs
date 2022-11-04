namespace MessengerMAUI;

public partial class PersonCardPattern : ContentView
{
    MainContent content;
    public PersonCardPattern(MainContent main, string Name = "", string ThisLastMessage = "", bool haveNewMessage = false, int newMessageCount = 0, bool haveIgnore = false, string time = "12:00", bool pushed = false, string IconColor = "default", string textColor = "default")
    {
        InitializeComponent();
        content = main;
        init(Name, ThisLastMessage, haveNewMessage, newMessageCount, haveIgnore, time: time, IconColor: IconColor, textColor: textColor);
        gridclkd();

        if (pushed)
        {
            setPushed();
        }
        else
        {
            setNotPushed();
        }
    }

    void init(string Name = "", string ThisLastMessage = "", bool haveNewMessage = false, int newMessageCount = 0, bool haveIgnore = false, string time = "12:00", string IconColor = "default", string textColor = "default")
    {
        TextIcon.Text = inicialsGenerator(Name);
        PersonName.Text = Name;
        LastMessage.Text = ThisLastMessage;
        if (haveNewMessage)
        {
            NumberNotifications.IsVisible = true;
            Quantity.IsVisible = true;
            Quantity.Text = newMessageCount.ToString();

        }
        else
        {
            NumberNotifications.IsVisible = false;
            Quantity.IsVisible = false;
        }
        if (haveNewMessage || haveIgnore)
        {
            Time.IsVisible = false;
        }
        else
        {
            Time.IsVisible = true;
            Time.Text = time;
        }
        //TODO: �������� ���������� ������ ������
        Ignor.IsVisible = haveIgnore;
        //TODO: �������� ����������� ���� �������������� �������� ��� �� ������
    }

    string inicialsGenerator(string Name) //����������� ���������� ����������� �� ����� �����������
    {
        if (Name != null)
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

    void gridclkd()
    {
        clk.GestureRecognizers.Add(new TapGestureRecognizer()
        {
            Command = new Command(() =>
            {
                card_Clicked();
            })
        });
    }

    private void openChat()
    {
        content.openChat(PersonName.Text);
    }

    public void setPushed()
    {
        if (pushed)
        {
            pushed = false;
        }
        card_Clicked();
    }

    public void setNotPushed()
    {
        if (!pushed)
        {
            pushed = true;
        }
        card_Clicked();
    }

    public bool pushed = false;
    private void card_Clicked()
    {
        if (!pushed)
        {
            card.Fill = Color.Parse("#333538");
            pushed = true;
            openChat();
        }
        else
        {
            card.Fill = Color.Parse("#161719");
            pushed = false;
        }
    }

    //TODO:�������� ����� ��������, ����������
}

