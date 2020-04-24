using System.Collections.Generic;

namespace TanulmanyiRendszer.DAL.Repositories
{
    public sealed class QueryResult<T>
    {
        public IEnumerable<T> Entities { get; internal set; }

        public int TotalCount { get; internal set; }
    }
}