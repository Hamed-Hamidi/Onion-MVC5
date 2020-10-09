using System;
using System.Collections.Generic;
using Onion.Data.Music;

namespace Onion.Service.Interfaces
{
    public interface ISingerService : IDisposable
    {
        List<Singer> GetAllSingers();
        void AddSinger(Singer singer);
        Singer GetSingerById(int singerId);
        void EditSinger(Singer singer);
    }
}