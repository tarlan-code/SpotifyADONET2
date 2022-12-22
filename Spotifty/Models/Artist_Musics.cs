using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifty.Models
{
    internal class Artist_Musics
    {
        public int Id { get; init; }

        public int ArtistId { get; set; }
        public int MusicId { get; set; }
    }
}
