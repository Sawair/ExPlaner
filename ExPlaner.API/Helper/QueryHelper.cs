using System.Linq;
using ExPlaner.API.DAL;

namespace ExPlaner.API.Helper
{
    public static class QueryHelper
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> queryable, int pageNumber, int pageSize) where T : class, IEntity
        {
            return queryable
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}