namespace MessengerMAUI;

public partial class ChatProcessor : ContentView
{
	public ChatProcessor()
	{
		InitializeComponent();
        MessagesGrid.VerticalOptions = LayoutOptions.End;
        MessagesGrid.HorizontalOptions = LayoutOptions.Fill;
    }

    List<Bubble> Messages = new List<Bubble>();

    public int LastMessageIndex = 0;

    private void SendButtonClicked(object sender, EventArgs e)
    {
        //DrawMessage(TextBox.Text, true);//Разкоменть это когда будешь писать соединение с сервером и закоменть то что ниже
        if (testSenderCheckBox.IsChecked == true)//UI Test "Кто отправляет сообщение"
        {
            DrawMessage(TextBox.Text, false);//Отправитель - собеседник
        }
        else
        {
            DrawMessage(TextBox.Text, true);//Отправитель - Я
        }
    }

    public void DrawMessage(string message, bool myMessage)
    {
        if (message != null)
        {
            Messages.Add(new Bubble());//Добовление в список новый класс Пузырька
            Messages[LastMessageIndex].BubbleCreator(message, myMessage);//Настройка Пузырька
            MessagesGrid.AddRowDefinition(new RowDefinition());//Добавление строки
            MessagesGrid.Add(Messages[LastMessageIndex], 0, LastMessageIndex);//Вызов Пузырька в таблицу
            Body.Content = MessagesGrid;//Обновление контента чата
            LastMessageIndex++;
        }
    }
}