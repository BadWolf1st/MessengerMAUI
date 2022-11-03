using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerMAUI.Objects
{
    public class People
    {
        public string name { get; set; }
        public string login { get; set; }
        public bool haveChat { get; set; }//Указывает что чат уже существует       
        public string lastMessage { get; set; }//Указывает последнее отправленное кем либо(мной или им) сообщение (Сюда нужно сгрузить само сообщение)
        public bool onlineStatus { get; set; }//Online\Offline (True\False)
        public bool friendStatus { get; set; } //Друзья\Не друзья (True\False)
        public string lastMessageTime { get; set; }//Время формата: 19:30 в виде строки
        public bool IsReadLastMessage { get; set; }//Указывает прочёл ли собеседник моё сообщение
        public bool IsSendLastMessage { get; set; } //Указывает отправил ли мне собеседник новое сообщение, не прочитанное мной
        public string IconTextColor { get; set; }
        public string IconColor { get; set; }
    }
}
