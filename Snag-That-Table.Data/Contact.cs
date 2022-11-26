using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snag_That_Table.Data
{
    public class Contact
    {
        [Key]
        public int MessagesId { get; set; }
        public Guid UserId { get; set; }
        public Guid RestaurantId { get; set; }
        public DateTime DateSent { get; set; }
        public string Content { get; set; }
    }
}
