using System;
using System.Collections.Generic;
using System.Linq;
using Onion.Data.Access;
using Onion.Data.Account;
using Onion.Repository.DataTransfer;
using Onion.Service.DTO.Paging;
using Onion.Service.DTO.User;
using Onion.Service.Extensions;
using Onion.Service.Interfaces;

namespace Onion.Service.Implementation
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        private IRepository<UserRole> _userRoleRepository;

        public UserService(IRepository<User> userRepository, IRepository<UserRole> userRoleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }


        public User GetUserByUserId(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public void CreateUser(User user)
        {
            _userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            UpdateUser(user);
        }

        public void DelelteUser(int userId)
        {
            var user = GetUserByUserId(userId);
            user.IsDelete = true;
            UpdateUser(user);
        }

        public List<UserItemDTO> GetUsers()
        {
            return _userRepository.Get(null).Select(s => new UserItemDTO
            {
                Email = s.Email,
                UserName = s.UserName
            }).ToList();
        }

        public bool IsExistUserByUserName(string userName)
        {
            return _userRepository.IsExist(s => s.UserName == userName);
        }

        public bool IsExistUserByUserName(string userName, string currenUserName)
        {
            return _userRepository.IsExist(s => s.UserName == userName && s.UserName != currenUserName);
        }

        public bool IsExistUserByEmail(string email)
        {
            return _userRepository.IsExist(s => s.Email == email);
        }

        public bool IsExistUserByEmail(string email, string currentEmail)
        {
            return _userRepository.IsExist(s => s.Email == email && s.Email != currentEmail);
        }

        public User GetUserByActiveCode(string activeCode)
        {
            return _userRepository.Get(s => s.ActiveCode == activeCode).SingleOrDefault();
        }

        public User GetUserByUserName(string userName)
        {
            return _userRepository.Get(s => s.UserName == userName).SingleOrDefault();
        }

        public AdminUsersDto GetUsersByFilter(AdminUsersDto filter)
        {
            var query = _userRepository.Get(null).AsQueryable().SetUsersFilter(filter);

            var count = (int)Math.Ceiling(query.Count() / (double)filter.TakeEntity);

            var pager = Pager.Build(count, filter.PageId, filter.TakeEntity);

            var users = query.OrderByDescending(s => s.Id).Paging(pager).ToList();

            return filter.SetUsers(users).SetPagingItems(pager);
        }

        public AdminEditUser GetUserForEdit(int userId)
        {
            var user = GetUserByUserId(userId);

            if (user == null) return null;

            return new AdminEditUser
            {
                Email = user.Email,
                UserId = user.Id,
                CurrentEmail = user.Email,
                UserName = user.UserName,
                CurrentUserName = user.UserName,
                IsActive = user.IsActive
            };
        }

        public bool HasUserThisPermission(string permissionName, string userName)
        {
            return _userRoleRepository.Any(s => s.Role.Name == permissionName && s.User.UserName == userName);
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}
