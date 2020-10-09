using Onion.Data.Account;
using Onion.Data.Common;

namespace Onion.Data.Access
{
    public class UserRole : BaseEntity
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public User User { get; set; }

        public Role Role { get; set; }
    }
}
