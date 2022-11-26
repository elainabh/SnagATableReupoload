using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Snag_That_Table.Data;
using Snag_That_Table.Models.RestaurantModels;

namespace Snag_That_Table.Services.RestaurantServices
{
    public class RestaurantServices : IRestaurantServices
    {
        private Guid _userId;
        private readonly ApplicationDbContext _context;

        public RestaurantServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SetUserId(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateRestaurant(RestaurantCreate model)
        {
         
                var restaurantEntity = new Restaurant()
                {
                    OwnerId = _userId,
                    RestaurantName = model.RestaurantName,
                    RestaurantAddress = model.RestaurantAddress,
                    RestaurantPhoneNumber = model.RestaurantPhoneNumber

                };
                _context.Restaurants.Add(restaurantEntity);
                return _context.SaveChanges() == 1;
            
        }
        public IEnumerable<RestaurantListItem> GetAllRestaurants()
        {
                List<RestaurantListItem> entity =
                    _context
                        .Restaurants
                        .Select(r => new RestaurantListItem()
                        {
                            RestaurantName = r.RestaurantName,
                            RestaurantAddress = r.RestaurantAddress,
                            RestaurantPhoneNumber = r.RestaurantPhoneNumber
                        })
                .ToList();
                return entity;
        }
        public async Task<RestaurantListItem> GetRestaurantByIdAsync(Guid restaurantId)
        {
                var entity =
                    _context
                    .Restaurants
                     .FindAsync(restaurantId)
                     .Result;
                if (entity == null)
                    return null;
                var detail = new RestaurantListItem
                {
                    RestaurantName = entity.RestaurantName,
                    RestaurantAddress = entity.RestaurantAddress,
                    RestaurantPhoneNumber = entity.RestaurantPhoneNumber,
                };
            return detail;
        }
        public bool UpdateRestaurant(RestaurantUpdate model, Guid restaurantId)
        {
                var entity = _context.Restaurants.Single(r => r.RestaurantId == restaurantId && r.OwnerId == _userId);
                entity.RestaurantName = model.RestaurantName;
                entity.RestaurantPhoneNumber = model.RestaurantPhoneNumber;
                entity.RestaurantAddress = model.RestaurantPhoneNumber;
                return _context.SaveChanges() == 1;
        }
        public bool DeleteARestaurant(Guid restaurantId)
        {
                var entity =
                    _context
                    .Restaurants
                    .FirstOrDefault(r => r.RestaurantId == restaurantId && r.OwnerId == _userId);
                if (entity is null)
                    return false;
                _context.Restaurants.Remove(entity);

                return _context.SaveChanges() == 1;
        }
    }
}
