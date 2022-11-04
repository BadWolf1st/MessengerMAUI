namespace MessengerMAUI;

public partial class Bubble : ContentView
{
    public Bubble(string message, bool senderIsUser)
    {
        InitializeComponent();
        BubbleCreator(message, senderIsUser);
    }
    public void BubbleCreator(string Message, bool SenderIsUser)
    {

        ThisMessageLabel.Text = Message;
        if (SenderIsUser == true)
        {
            ThisMessageBubble.Fill = Color.Parse("#0066DC");
            ThisBubbleGrid.HorizontalOptions = LayoutOptions.End;
        }
        else
        {
            ThisMessageBubble.Fill = Color.Parse("#303030");
            ThisBubbleGrid.HorizontalOptions = LayoutOptions.Start;
        }
    }
}