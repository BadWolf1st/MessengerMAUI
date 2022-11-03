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
                addNewFriendCard(main.peoples[currentPeople].name, main.peoples[currentPeople].friendStatus, currentPeople, main.peoples[currentPeople].onlineStatus);
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

    public void addNewFriendCard(string name, bool IsFriend, int numOfRow, bool IsOnline = true)
    {
        listOfFriends.Add(new FriendsPattern(name, IsFriend, IsOnline), 0, numOfRow);
    }
}