using System.Collections.Generic;

namespace TrainTable.Repositories
{
    public interface IRepository<out T>
    {
        IEnumerable<T> GetAll();
    }
}
