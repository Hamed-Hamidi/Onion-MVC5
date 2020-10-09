using System.Collections.Generic;
using Onion.Service.DTO.Paging;

namespace Onion.Service.DTO.Song
{
    public class AllSongsDTO : BasePaging
    {
        public List<Data.Music.Song> Songs { get; set; }

        public AllSongsDTO SetSongs(List<Data.Music.Song> songs)
        {
            Songs = songs;

            return this;
        }

        public AllSongsDTO SetPaging(BasePaging paging)
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
    }
}
