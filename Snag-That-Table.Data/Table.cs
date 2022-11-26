using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snag_That_Table.Data
{
    public class Table
    {
        public int TableId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid RestaurantId { get; set; }
        public Guid ConfirmationNumber { get; set; }
        public int MinSeatedAtTable { get; set; }
        public int MaxSeatedAtTable { get; set; }
        public DateTime StartTime { get; set; }
        public virtual string RestaurantName { get; set; }

    }
}
