using ApiRequestCaching.Shared;
using System.Collections.Generic;

namespace ApiRequestCaching.Data
{
    public class DataRepository : IDataRepository
    {
        public IReadOnlyCollection<string> GetData(int id)
        {
            var result = Database.Query(id);

            return result;
        }
    }
}
