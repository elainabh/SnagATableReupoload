using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snag_That_Table.Models.Table
{
    public class TableCreate
    {
        public int TableId { get; set; }
        public Guid RestaurantId { get; set; }
        public int MinSeatedAtTable { get; set; }
        public int MaxSeatedAtTable { get; set; }
        public DateTime StartTime { get; set; }
        public virtual string RestaurantName { get; set; }
    }
}
