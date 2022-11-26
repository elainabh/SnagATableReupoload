using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snag_That_Table.Models.Messages
{
    public class MessagesListItem
    {
        public Guid RestaurantId { get; set; }
        public DateTime DateSent { get; set; }
        public string Content { get; set; }
    }
}
