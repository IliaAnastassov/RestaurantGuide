using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantGuide.DataAccess.Repositories.Interfaces;
using RestaurantGuide.Entities;

namespace RestaurantGuide.Web.Tests.Mocks
{
    class MockRestaurantRepository : IRestaurantRepository
    {
        private IEnumerable<Restaurant> _restaurants;

        public MockRestaurantRepository(IEnumerable<Restaurant> restaurants)
        {
            _restaurants = restaurants;
        }

        public void Add(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Restaurant Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetAll(string filter = null)
        {
            throw new NotImplementedException();
        }

        public Restaurant GetBestRestaurant()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetTopRestaurants()
        {
            return _restaurants.Take(10);
        }

        public void Update(Restaurant entity)
        {
            throw new NotImplementedException();
        }
    }
}
