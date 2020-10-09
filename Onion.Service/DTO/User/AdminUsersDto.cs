using System.Collections.Generic;
using Onion.Service.DTO.Paging;

namespace Onion.Service.DTO.User
{
    public class AdminUsersDto : BasePaging
    {
        public string FilterEmail { get; set; }

        public List<Data.Account.User> Users { get; set; }

        public AdminUsersDto SetPagingItems(BasePaging paging)
        {
            PageId = paging.PageId;
            ActivePage = paging.ActivePage;
            PageCount = paging.PageCount;
            StartPage = paging.StartPage;
            EndPage = paging.EndPage;
            TakeEntity = paging.TakeEntity;
            SkipEntity = paging.SkipEntity;

            return this;
        }

        public AdminUsersDto SetUsers(List<Data.Account.User> users)
        {
            Users = users;

            return this;
        }
    }
}
