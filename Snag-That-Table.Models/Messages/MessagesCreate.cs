using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snag_That_Table.Models.Messages
{
    public class MessagesCreate
    {
        [ForeignKey("RestaurantId")]
        public Guid RestaurantId { get; set; }
        public DateTime DateSent { get; set; }
        public string Content { get; set; }
    }
}
