namespace MessengerMAUI;

public partial class ChatListCostructure : ContentView
{
	public ChatListCostructure()
	{
		InitializeComponent();
	}

	List<PersonCardPattern> cards = new();
	int lastItem = 0;

	public void generateCard(string Name = "", string ThisLastMessage = "", bool haveNewMessage = false, int newMessageCount = 0, bool haveIgnore = false, string IconColor = "Deafult", string textColor = "Default", bool pushed = false)
	{
		Chat.AddRowDefinition(new RowDefinition());
        cards.Add(new PersonCardPattern(Name, ThisLastMessage, haveNewMessage, newMessageCount, haveIgnore, IconColor, textColor));
		Chat.Add(cards[lastItem] , 0, lastItem);
		lastItem++;
	}
}