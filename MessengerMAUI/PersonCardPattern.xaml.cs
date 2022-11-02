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
		//TODO: Добавить обработчик цветов иконки
		Ignor.IsVisible = haveIgnore; 
		//TODO: Добавить контекстное меню обрабатываемое нажатием ПКМ по иконке
		//TODO: !!!Изменить базу под единую кнопку!!!
	}

	string inicialsGenerator(string Name) //Конструктор инициаллов собеседника из имени собесденика
	{
		if (Name != null)
		{
            string inicials = Name[0].ToString();//Копируем первый символ из Фамилии собеседника

			int i = 1;
			while(i <= Name.Length)
			{
				if (Name[i]==' ')//Ищем разрыв в строке между имененм и фамилией
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

	//TODO:Добавить метод удаления, обнавления
}

