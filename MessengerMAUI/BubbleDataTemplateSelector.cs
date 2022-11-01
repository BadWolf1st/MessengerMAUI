using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerMAUI
{
    internal class BubbleDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MyMessage { get; set; }
        public DataTemplate NotMyMessage { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (((ThisBubble)item).UserMessage == true)
            {
                return MyMessage;
            }
            else
            {
                return NotMyMessage;
            }
        }
    }
}
