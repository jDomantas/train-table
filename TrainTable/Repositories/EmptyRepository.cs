using System.Collections.Generic;
using System.Linq;

namespace TrainTable.Repositories
{
    public class EmptyRepository<T> : IRepository<T>
    {
        public IEnumerable<T> GetAll()
        {
            return Enumerable.Empty<T>();
        }
    }
}
