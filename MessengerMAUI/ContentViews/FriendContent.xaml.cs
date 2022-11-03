using MessengerMAUI.Objects;
using MessengerMAUI.Patterns;
using Microsoft.Maui.Platform;

namespace MessengerMAUI;

public partial class FriendContent : ContentView
{
    MainContent main;
    public FriendContent(MainContent mainContent)
    {
        InitializeComponent();
        main = mainContent;
        initElement();
    }

    void initElement()
    {
        if (main.peoples.Count > 0)
        {
            int currentPeople = 0;
            while (currentPeople < main.peoples.Count)
            {
                listOfFriends.AddRowDefinition(new RowDefinition());
                People people = main.peoples[currentPeople];
                addNewFriendCard(people.name, people.friendStatus, currentPeople, people.onlineStatus);
                currentPeople++;
            }
            ScrollViewList.Content = listOfFriends;
        }
    }

    public void reInitElement()
    {
        listOfFriends.Clear();
        initElement();
    }


    List<FriendsPattern> friendsPatterns = new();
    public void addNewFriendCard(string name, bool IsFriend, int numOfRow, bool IsOnline = true)
    {
        friendsPatterns.Add(new FriendsPattern(name, IsFriend, IsOnline));
        listOfFriends.Add(friendsPatterns[numOfRow], 0, numOfRow);
    }
}