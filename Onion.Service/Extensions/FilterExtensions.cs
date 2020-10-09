using System.Linq;
using Onion.Data.Account;
using Onion.Service.DTO.User;

namespace Onion.Service.Extensions
{
    public static class FilterExtensions
    {
        #region Users

        public static IQueryable<User> SetUsersFilter(this IQueryable<User> queryable, AdminUsersDto filter)
        {
            if (!string.IsNullOrEmpty(filter.FilterEmail))
            {
                queryable = queryable.Where(s => s.Email.Contains(filter.FilterEmail));
            }

            return queryable;
        }

        #endregion
    }
}
