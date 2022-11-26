using Snag_That_Table.Data;
using Snag_That_Table.Models.RestaurantModels;
using Snag_That_Table.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Snag_That_Table.Services.TableServices
{
    public class TableServices : ITableServices
    {
        private Guid _userId;
        private readonly ApplicationDbContext _context;

        public TableServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public void SetUserId(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTable(TableCreate model)
        {
                var entity = _context.Tables.Single(t => t.RestaurantId == model.RestaurantId && t.OwnerId == _userId);
                new Table()
                {
                    TableId = model.TableId,
                    RestaurantId = model.RestaurantId,
                    MinSeatedAtTable = model.MinSeatedAtTable,
                    MaxSeatedAtTable = model.MaxSeatedAtTable

                };
                _context.Tables.Add(entity);
                return _context.SaveChanges() == 1;
        }
        public async Task<List<TableListItem>> GetAllTables()
        {
                List<TableListItem> entity =
                    _context
                        .Tables
                        .Select(t => new TableListItem()
                        {
                            MinSeatedAtTable = t.MinSeatedAtTable,
                            MaxSeatedAtTable = t.MaxSeatedAtTable,
                            RestaurantName = t.RestaurantName,
                            StartTime = t.StartTime
                        })

                .ToList();
                return entity;
        }

        public bool UpdateATable(TableUpdate model)
        {
                var entity = _context.Tables.Single(t => t.TableId == model.TableId && t.OwnerId == _userId);
                entity.MinSeatedAtTable = model.MinSeatedAtTable;
                entity.MaxSeatedAtTable = model.MaxSeatedAtTable;
                return _context.SaveChanges() == 1;
        }
        public bool MakeAReservation(TableUpdate model)
        {
                var entity =
                    _context
                    .Tables
                    .Select(t => new TableUpdate()
                    {

                        ConfirmationNumber = _userId,
                        StartTime = model.StartTime,

                    });
                return _context.SaveChanges() == 1;
        }

        public bool DeleteTable(int tableId)
        {
                var entity =
                    _context
                    .Tables
                    .Single(r => r.TableId == tableId && r.OwnerId == _userId);
                _context.Tables.Remove(entity);

                return _context.SaveChanges() == 1;
        }

    }
}
