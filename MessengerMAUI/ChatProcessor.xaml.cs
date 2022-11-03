using MessengerMAUI.Objects;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;

namespace MessengerMAUI;

public partial class ChatProcessor : ContentView
{
    public ChatProcessor(string Name)
    {
        InitializeComponent();

        //MessagesGrid.VerticalOptions = LayoutOptions.End;
        //MessagesGrid.HorizontalOptions = LayoutOptions.Fill;
        ChatName.Text = Name;


    }

    private List<ThisBubble> Messages = new();
    private List<Bubble> Bubbles = new();

    public int LastMessageIndex = 0;

    private void SendButtonClicked(object sender, EventArgs e)
    {
        //DrawMessage(TextBox.Text, true);//���������� ��� ����� ������ ������ ���������� � �������� � ��������� �� ��� ����
        if (testSenderCheckBox.IsChecked)// HACK: UI Test "��� ���������� ���������"
        {
            DrawMessage(TextBox.Text, false);//����������� - ����������
        }
        else
        {
            DrawMessage(TextBox.Text, true);//����������� - �
        }
        TextBox.Text = "";//������� ���� �����
    }

    public void DrawMessage(string message, bool IsMyMessage, int timeMin = 0, int timeHour = 0/*, string date*/ )//Adding Message like a bubble
    {
        if (message != null)
        {
            //MessagesGrid.AddRowDefinition(new RowDefinition());
            //MessagesGrid.Add(Messages[LastMessageIndex], 0, LastMessageIndex);
            //Body.Content = MessagesGrid;//Update chat content

            //Body.ScrollToAsync(0, Body.ContentSize.Height, true);//UNDONE //scrolling to end //������ ������ �� stackoverflow https://stackoverflow.com/questions/74167376/maui-scrollview-to-end

            //LastMessageIndex++;


            Messages.Add(new ThisBubble());
            Messages[LastMessageIndex].Message = message;
            Messages[LastMessageIndex].sendTime = timeHour.ToString() + ":" + timeMin.ToString();
            Messages[LastMessageIndex].UserMessage = IsMyMessage;

            //Body.AddLogicalChild(new Bubble(Messages[LastMessageIndex].Message, Messages[LastMessageIndex].UserMessage));
            //Body.ItemsSource = Messages; //������ �**�� ��� ������� ������ ���� ���������!!!!

            Bubbles.Add(new Bubble(Messages[LastMessageIndex].Message, true));

            BindableLayout.SetItemsSource(BodyContent, Messages.ToArray());
            BindableLayout.SetItemTemplateSelector(BodyContent, new BubbleDataTemplateSelector());

            LastMessageIndex++;
        }
    }
}