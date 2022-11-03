using MessengerMAUI.Patterns;

namespace MessengerMAUI;

public partial class FriendContent : ContentView
{
	public FriendContent()
	{
		InitializeComponent();
		addNewFriendCard();
	}

	public void addNewFriendCard()
	{
		FriendsPattern friend = new FriendsPattern();
		listOfFriends.Add(friend);
	}
}