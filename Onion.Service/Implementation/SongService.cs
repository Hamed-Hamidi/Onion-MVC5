using System;
using System.Collections.Generic;
using System.Linq;
using Onion.Data.Music;
using Onion.Repository.DataTransfer;
using Onion.Service.DTO.Paging;
using Onion.Service.DTO.Song;
using Onion.Service.Extensions;
using Onion.Service.Interfaces;

namespace Onion.Service.Implementation
{
    public class SongService : ISongService
    {
        private readonly IRepository<Song> _songRepository;

        private readonly IRepository<SongLike> _songLikeRepository;

        private readonly IRepository<SongVisit> _songVisitRepository;

        public SongService(IRepository<Song> songRepository, IRepository<SongLike> songLikeRepository, IRepository<SongVisit> songVisitRepository)
        {
            _songRepository = songRepository;
            _songLikeRepository = songLikeRepository;
            _songVisitRepository = songVisitRepository;
        }


        public List<Song> GetAllSingerSongs(int singerId)
        {
            return _songRepository.Get(s => s.SingerId == singerId).ToList();
        }

        public void AddSong(Song song)
        {
            _songRepository.Insert(song);
        }

        public Song GetSongById(int songId)
        {
            return _songRepository.GetById(songId);
        }

        public void EditSong(Song song)
        {
            _songRepository.Update(song);
        }

        public List<Song> GetLatestSongsForHeader()
        {
            return _songRepository.Get(s => s.IsActive && !s.IsDelete).OrderByDescending(s => s.CreateDate).Take(8).ToList();
        }

        public AllSongsDTO GetAllSongs(AllSongsDTO filter)
        {
            var query = _songRepository.Get(null).AsQueryable();

            var count = (int)Math.Ceiling(query.Count() / (double)filter.TakeEntity);

            var pager = Pager.Build(count, filter.PageId, filter.TakeEntity);

            var songs = query.OrderByDescending(s => s.Id).Paging(pager).ToList();

            return new AllSongsDTO().SetSongs(songs).SetPaging(pager);
        }

        public SingleSongDTO GetSingleSong(int songId)
        {
            var song = _songRepository.GetById(songId);

            if (song == null) return null;

            var otherSongs = _songRepository.Get(s => s.IsActive && !s.IsDelete && s.SingerId == song.SingerId && s.Id != songId).OrderByDescending(s => s.CreateDate).Take(4).ToList();

            return new SingleSongDTO
            {
                Song = song,
                Songs = otherSongs
            };
        }

        public bool IsExistSongById(int songId)
        {
            return _songRepository.Any(s => s.Id == songId);
        }

        public bool HasUserLikedSong(int songId, string userIP)
        {
            return _songLikeRepository.Any(s => s.SongId == songId && s.UserIP == userIP);
        }

        public void DisLikeSong(int songId, string userIP)
        {
            var like = _songLikeRepository.Get(s => s.SongId == songId && s.UserIP == userIP).SingleOrDefault();

            if (like != null) _songLikeRepository.Delete(like);
        }

        public void LikeSong(int songId, string userIP)
        {
            _songLikeRepository.Insert(new SongLike
            {
                SongId = songId,
                UserIP = userIP
            });
        }

        public bool HasUserVisitedSong(int songId, string userIP)
        {
            return _songVisitRepository.Any(s => s.SongId == songId && s.UserIP == userIP);
        }

        public void AddVisitForSong(int songId, string userIP)
        {
            _songVisitRepository.Insert(new SongVisit
            {
                SongId = songId,
                UserIP = userIP
            });
        }

        public List<Song> GetFavoritesSongs()
        {
            return _songRepository.Get(s => s.IsActive && !s.IsDelete).OrderByDescending(s => s.SongLikes.Count).Take(12).ToList();
        }

        public List<Song> GetSongsOrderedByVisit()
        {
            return _songRepository.Get(s => s.IsActive && !s.IsDelete).OrderByDescending(s => s.SongVisits.Count).Take(12).ToList();
        }

        public void Dispose()
        {
            _songRepository.Dispose();
        }
    }
}