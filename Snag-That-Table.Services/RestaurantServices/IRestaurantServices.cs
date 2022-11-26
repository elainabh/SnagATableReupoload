using Snag_That_Table.Models.RestaurantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snag_That_Table.Services.RestaurantServices
{
    public interface IRestaurantServices
    {
        bool CreateRestaurant(RestaurantCreate model);
        IEnumerable<RestaurantListItem> GetAllRestaurants();        
        bool UpdateRestaurant(RestaurantUpdate model, Guid restaurantId);
        bool DeleteARestaurant(Guid restaurantId);
        Task<RestaurantListItem> GetRestaurantByIdAsync(Guid restaurantId);
        void SetUserId(Guid userId);



    }
}
