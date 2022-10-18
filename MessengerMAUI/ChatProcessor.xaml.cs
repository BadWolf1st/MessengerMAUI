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
        //DrawMessage(TextBox.Text, true);//���������� ��� ����� ������ ������ ���������� � �������� � ��������� �� ��� ����
        if (testSenderCheckBox.IsChecked == true)//UI Test "��� ���������� ���������"
        {
            DrawMessage(TextBox.Text, false);//����������� - ����������
        }
        else
        {
            DrawMessage(TextBox.Text, true);//����������� - �
        }
    }

    public void DrawMessage(string message, bool myMessage)
    {
        if (message != null)
        {
            Messages.Add(new Bubble());//���������� � ������ ����� ����� ��������
            Messages[LastMessageIndex].BubbleCreator(message, myMessage);//��������� ��������
            MessagesGrid.AddRowDefinition(new RowDefinition());//���������� ������
            MessagesGrid.Add(Messages[LastMessageIndex], 0, LastMessageIndex);//����� �������� � �������
            Body.Content = MessagesGrid;//���������� �������� ����
            LastMessageIndex++;
        }
    }
}