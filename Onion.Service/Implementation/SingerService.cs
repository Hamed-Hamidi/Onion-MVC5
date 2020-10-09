using System.Collections.Generic;
using System.Linq;
using Onion.Data.Music;
using Onion.Repository.DataTransfer;
using Onion.Service.Interfaces;

namespace Onion.Service.Implementation
{
    public class SingerService : ISingerService
    {
        private readonly IRepository<Singer> _singerRepository;

        public SingerService(IRepository<Singer> singerRepository)
        {
            _singerRepository = singerRepository;
        }

        public List<Singer> GetAllSingers()
        {
            return _singerRepository.Get(null).ToList();
        }

        public void AddSinger(Singer singer)
        {
            _singerRepository.Insert(singer);
        }

        public Singer GetSingerById(int singerId)
        {
            return _singerRepository.GetById(singerId);
        }

        public void EditSinger(Singer singer)
        {
            _singerRepository.Update(singer);
        }

        public void Dispose()
        {
            _singerRepository.Dispose();
        }
    }
}
