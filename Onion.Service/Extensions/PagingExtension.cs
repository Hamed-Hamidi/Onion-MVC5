using System.Linq;
using Onion.Service.DTO.Paging;

namespace Onion.Service.Extensions
{
    public static class PagingExtension
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> queryable, BasePaging pager)
        {
            return queryable.Skip(pager.SkipEntity).Take(pager.TakeEntity);
        }
    }
}
