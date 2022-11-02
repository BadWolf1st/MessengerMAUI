namespace MessengerMAUI;

public partial class PersonCardPattern : ContentView
{
	public PersonCardPattern(string Name = "", string ThisLastMessage = "", bool haveNewMessage = false, int newMessageCount = 0, bool haveIgnore = false, string IconColor = "Deafult", string textColor = "Default", bool pushed = false)
	{
		InitializeComponent();
		init(Name, ThisLastMessage, haveNewMessage, newMessageCount, haveIgnore, IconColor, textColor);
	}

	void init(string Name="", string ThisLastMessage="", bool haveNewMessage = false, int newMessageCount=0, bool haveIgnore = false, string IconColor = "Deafult", string textColor = "Default", bool pushed = false)
	{
		TextIcon.Text = inicialsGenerator(Name);
		PersonName.Text = Name;
		LastMessage.Text = ThisLastMessage;
		if (haveNewMessage)
		{
			NumberNotifications.IsVisible = true;
            Quantity.IsVisible=true;
			Quantity.Text = newMessageCount.ToString();

		}
		else
		{
            NumberNotifications.IsVisible = false;
            Quantity.IsVisible = false;
        }
		if (pushed)
		{
			card.Fill = Color.Parse("#333538");
		}
		else
		{
            card.Fill = Color.Parse("#161719");
        }
		//TODO: �������� ���������� ������ ������
		Ignor.IsVisible = haveIgnore; 
		//TODO: �������� ����������� ���� �������������� �������� ��� �� ������
		//TODO: !!!�������� ���� ��� ������ ������!!!
	}

	string inicialsGenerator(string Name) //����������� ���������� ����������� �� ����� �����������
	{
		if (Name != null)
		{
            string inicials = Name[0].ToString();//�������� ������ ������ �� ������� �����������

			int i = 1;
			while(i <= Name.Length)
			{
				if (Name[i]==' ')//���� ������ � ������ ����� ������� � ��������
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

	//TODO:�������� ����� ��������, ����������
}

