﻿using System.Collections.Generic;

namespace RestaurantGuide.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T>
        where T : new()
    {
        T Get(int id);
        IEnumerable<T> GetAll(string filter);
        void Add(T entity);
        void Edit(T entity);
        void Delete(int id);
    }
}
