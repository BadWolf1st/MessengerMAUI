namespace MessengerMAUI;

public partial class ChatProcessor : ContentView
{
	public ChatProcessor(string Name)
	{
		InitializeComponent();
        MessagesGrid.VerticalOptions = LayoutOptions.End;
        MessagesGrid.HorizontalOptions = LayoutOptions.Fill;
        ChatName.Text = Name;
    }

    List<Bubble> Messages = new();

    public int LastMessageIndex = 0;

    private void SendButtonClicked(object sender, EventArgs e)
    {
        //DrawMessage(TextBox.Text, true);//Разкоменть это когда будешь писать соединение с сервером и закоменть то что ниже
        if (testSenderCheckBox.IsChecked)// HACK: UI Test "Кто отправляет сообщение"
        {
            DrawMessage(TextBox.Text, false);//Отправитель - собеседник
        }
        else
        {
            DrawMessage(TextBox.Text, true);//Отправитель - Я
        }
        TextBox.Text = "";//Очистка поля ввода
    }

    public async void DrawMessage(string message, bool IsMyMessage)//Adding Message like a bubble
    {
        if (message != null)
        {
            
            Messages.Add(new Bubble());
            Messages[LastMessageIndex].BubbleCreator(message, IsMyMessage);
            MessagesGrid.AddRowDefinition(new RowDefinition());
            MessagesGrid.Add(Messages[LastMessageIndex], 0, LastMessageIndex);
            Body.Content = MessagesGrid;//Update chat content

            Body.ScrollToAsync(0, Body.ContentSize.Height, true);//UNDONE //scrolling to end //Поднял вопрос на stackoverflow https://stackoverflow.com/questions/74167376/maui-scrollview-to-end

            LastMessageIndex++;
        }
    }

    
}