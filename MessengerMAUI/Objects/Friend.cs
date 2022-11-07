using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerMAUI.Objects
{
    public class Friend : People
    {
        public bool haveChat { get; set; }
        public string lastMessage { get; set; }
        public string iconColor { get; set; }
        public string BackColor { get; set; }
        public string time { get; set; }
        public bool IsReadLastMessage { get; set; }
        public bool IsSendLastMessage { get; set; }
    }
}
