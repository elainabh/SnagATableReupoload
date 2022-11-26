using Snag_That_Table.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snag_That_Table.Services.TableServices
{
    public interface ITableServices
    {
        bool CreateTable(TableCreate model);
        Task<List<TableListItem>> GetAllTables();
        bool UpdateATable(TableUpdate model);
        bool MakeAReservation(TableUpdate model);
        bool DeleteTable(int tableId);
        void SetUserId(Guid userId);


    }
}
