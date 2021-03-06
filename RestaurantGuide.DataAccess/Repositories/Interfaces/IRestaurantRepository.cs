﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantGuide.Entities;

namespace RestaurantGuide.DataAccess.Repositories.Interfaces
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        IEnumerable<Restaurant> GetTopRestaurants();
        Restaurant GetBestRestaurant();
    }
}
