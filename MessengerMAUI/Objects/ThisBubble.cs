namespace MessengerMAUI.Objects
{
    public class ThisBubble
    {
        public string Message { get; set; }
        public string sendTime { get; set; }
        public bool UserMessage { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }
}
