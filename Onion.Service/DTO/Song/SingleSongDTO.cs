using System.Collections.Generic;

namespace Onion.Service.DTO.Song
{
    public class SingleSongDTO
    {
        public Data.Music.Song Song { get; set; }

        public List<Data.Music.Song> Songs { get; set; }
    }
}
