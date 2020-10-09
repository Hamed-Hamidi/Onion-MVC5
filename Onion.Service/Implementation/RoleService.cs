using Onion.Data.Access;
using Onion.Repository.DataTransfer;
using Onion.Service.Interfaces;

namespace Onion.Service.Implementation
{
    public class RoleService:IRoleService
    {
        private IRepository<Role> _roleRepository;

        public RoleService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public void Dispose()
        {
            _roleRepository.Dispose();
        }
    }
}