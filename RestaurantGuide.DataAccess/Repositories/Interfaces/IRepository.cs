using System.Collections.Generic;

namespace RestaurantGuide.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T>
        where T : new()
    {
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
