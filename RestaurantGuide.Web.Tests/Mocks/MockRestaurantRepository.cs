using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantGuide.DataAccess.Repositories.Interfaces;
using RestaurantGuide.Entities;

namespace RestaurantGuide.Web.Tests.Mocks
{
    class MockRestaurantRepository : IRestaurantRepository
    {
        private ICollection<Restaurant> _restaurants;

        public MockRestaurantRepository()
        {
            _restaurants = new List<Restaurant>();
        }

        public MockRestaurantRepository(ICollection<Restaurant> restaurants)
        {
            _restaurants = restaurants;
        }

        public void Add(Restaurant entity)
        {
            _restaurants.Add(entity);
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
            return _restaurants;
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
