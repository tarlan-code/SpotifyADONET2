using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifty.Models
{
    internal class Playlist_Musics
    {
        public int Id { get; init; }

        public int PlaylistId { get; set; }
        public int MusicId { get; set; }
    }
}
