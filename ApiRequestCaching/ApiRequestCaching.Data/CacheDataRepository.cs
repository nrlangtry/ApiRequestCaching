using ApiRequestCaching.Shared;
using System.Collections.Generic;

namespace ApiRequestCaching.Data
{
    public class CacheDataRepository : IDataRepository
    {
        IDictionary<int, IReadOnlyCollection<string>> DataCache = new Dictionary<int, IReadOnlyCollection<string>>();

        public IReadOnlyCollection<string> GetData(int id)
        {
            if (DataCache.ContainsKey(id))
            {
                DataCache.TryGetValue(id, out IReadOnlyCollection<string> data);
                return data;
            }
            else
            {
                var results = Database.Query(id);

                DataCache.Add(id, results);

                return results;
            }
        }
    }
}
