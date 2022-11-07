
/* Unmerged change from project 'MessengerMAUI (net6.0-maccatalyst)'
Before:
using System;
After:
using MessengerMAUI.Objects;
using System;
*/

/* Unmerged change from project 'MessengerMAUI (net6.0-windows10.0.19041.0)'
Before:
using System;
After:
using MessengerMAUI.Objects;
using System;
*/

/* Unmerged change from project 'MessengerMAUI (net6.0-ios)'
Before:
using System;
After:
using MessengerMAUI.Objects;
using System;
*/
using
/* Unmerged change from project 'MessengerMAUI (net6.0-maccatalyst)'
Before:
using System.Threading.Tasks;
using MessengerMAUI.Objects;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'MessengerMAUI (net6.0-windows10.0.19041.0)'
Before:
using System.Threading.Tasks;
using MessengerMAUI.Objects;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'MessengerMAUI (net6.0-ios)'
Before:
using System.Threading.Tasks;
using MessengerMAUI.Objects;
After:
using System.Threading.Tasks;
*/
MessengerMAUI.Objects;

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
