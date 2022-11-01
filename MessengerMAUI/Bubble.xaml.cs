using System.Xml.Linq;

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
        // TODO: ðåàëèçîâàòü èçìåíåíèå óãëîâ ïóçûðÿ â ñîîòâåòñòâèè ñ äèçàéíîì
        // TODO: ðåàëèçîâàòü ïåðåíîñ òåêñòà íà äðóãóþ ñòðîêó
        ThisMessageLabel.Text = Message;
        if (SenderIsUser == true)
        {
            ThisMessageBubble.Fill = Color.Parse("#0066DC");
            ThisBubbleGrid.HorizontalOptions = LayoutOptions.End;//Ñìåùåíèå âïðàâî
        }
        else
        {
            ThisMessageBubble.Fill = Color.Parse("#303030");
            ThisBubbleGrid.HorizontalOptions = LayoutOptions.Start;//Ñìåùåíèå âëåâî
        }
    }
}