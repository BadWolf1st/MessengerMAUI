using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerMAUI
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
