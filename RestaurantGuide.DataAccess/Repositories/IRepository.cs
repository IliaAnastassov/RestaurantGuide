using System.Collections.Generic;

namespace RestaurantGuide.DataAccess.Repositories
{
    public interface IRepository<T>
        where T : new()
    {
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
