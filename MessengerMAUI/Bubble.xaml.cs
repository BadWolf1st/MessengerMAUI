using System.Xml.Linq;

namespace MessengerMAUI;

public partial class Bubble : ContentView
{
	public Bubble()
	{
        InitializeComponent();
        
	}
    public void BubbleCreator(string Message, bool SenderIsUser)
    {//Нужно реализовать изменение углов пузыря в соответствии с дизайном
        ThisMessageLabel.Text = Message;
        if (SenderIsUser == true)
        {
            ThisMessageBubble.Fill = Color.Parse("#0066DC");
            ThisBubbleGrid.HorizontalOptions = LayoutOptions.End;//Смещение вправо
        }
        else
        {
            ThisMessageBubble.Fill = Color.Parse("#303030");
            ThisBubbleGrid.HorizontalOptions = LayoutOptions.Start;//Смещение влево
        }
    }
}