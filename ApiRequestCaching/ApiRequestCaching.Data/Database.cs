using System.Collections.Generic;
using System.Threading;

namespace ApiRequestCaching.Data
{
    public static class Database
    {
        static readonly IReadOnlyDictionary<int, IReadOnlyCollection<string>> TheData = new Dictionary<int, IReadOnlyCollection<string>>()
        {
            { 1, new List<string>() { "result1", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result",
                "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result",
                "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result",
                "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result"} },
            { 2, new List<string>() { "result2", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result",
                "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result",
                "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result",
                "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result"} },
            { 3, new List<string>() { "result3", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result",
                "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result",
                "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result",
                "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result"} },
            { 4, new List<string>() { "result4", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result",
                "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result",
                "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result",
                "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result"} },
            { 5, new List<string>() { "result5", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result",
                "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result",
                "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result",
                "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result", "result"} }
        };

        public static IReadOnlyCollection<string> Query(int id)
        {
            // Emulate a little delay on the DB
            Thread.Sleep(100);

            TheData.TryGetValue(id, out IReadOnlyCollection<string> data);

            return data;
        }
    }
}
