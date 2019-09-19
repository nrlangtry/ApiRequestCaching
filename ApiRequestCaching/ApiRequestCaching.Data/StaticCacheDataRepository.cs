using ApiRequestCaching.Shared;
using System;
using System.Collections.Generic;

namespace ApiRequestCaching.Data
{
    public class StaticCacheDataRepository : IDataRepository
    {
        public IReadOnlyCollection<string> GetData(int id)
        {
            throw new NotImplementedException();
        }
    }
}
