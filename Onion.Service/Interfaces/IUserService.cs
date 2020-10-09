using System;
using System.Collections.Generic;
using Onion.Data.Account;
using Onion.Service.DTO.User;

namespace Onion.Service.Interfaces
{
    public interface IUserService : IDisposable
    {
        User GetUserByUserId(int userId);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        void DelelteUser(int userId);
        List<UserItemDTO> GetUsers();
        bool IsExistUserByUserName(string userName);
        bool IsExistUserByUserName(string userName, string currenUserName);
        bool IsExistUserByEmail(string email);
        bool IsExistUserByEmail(string email, string currentEmail);
        User GetUserByActiveCode(string activeCode);
        User GetUserByUserName(string userName);
        AdminUsersDto GetUsersByFilter(AdminUsersDto filter);
        AdminEditUser GetUserForEdit(int userId);
        bool HasUserThisPermission(string permissionName, string userName);
    }
}