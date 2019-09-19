using System.Collections.Generic;

namespace ApiRequestCaching.Shared
{
    public interface IDataRepository
    {
        IReadOnlyCollection<string> GetData(int id);
    }
}