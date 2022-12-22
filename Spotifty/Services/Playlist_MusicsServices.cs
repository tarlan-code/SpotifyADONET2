using Spotifty.Abstractions;
using Spotifty.Helper;
using Spotifty.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifty.Services
{
    internal class Playlist_MusicsServices:IService<Playlist_Musics>
    {
        public void Add(Playlist_Musics model)
        {
            SQL.ExecCommand($"INSERT INTO Playlist_Musics VALUES ({model.PlaylistId},{model.MusicId})");
        }

        public Playlist_Musics GetById(int id)
        {
            DataTable dt = SQL.ExecQuery($"SELECT * FROM Playlist_Musics WHERE Id = {id}");
            Playlist_Musics playlist_Musics = null;
            foreach (DataRow dr in dt.Rows)
            {
                playlist_Musics = new Playlist_Musics()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    PlaylistId = Convert.ToInt32(dr["PlaylistId"]),
                    MusicId = Convert.ToInt32(dr["MuiscId"])
                };
            }

            return playlist_Musics;
        }

        public List<Playlist_Musics> GetData()
        {
            List<Playlist_Musics> list = new List<Playlist_Musics>();
            DataTable dt = SQL.ExecQuery("SELECT * FROM Playlist_Musics");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Playlist_Musics()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    PlaylistId = Convert.ToInt32(dr["PlaylistId"]),
                    MusicId = Convert.ToInt32(dr["MuiscId"])

                });
            }
            return list;
        }

        public void Remove(int id)
        {

            int result = SQL.ExecCommand($"DELETE Playlist_Musics WHERE Id={id}");
            Console.ForegroundColor = ConsoleColor.Red;
            if (result == 0)
                Console.WriteLine($"{id} ID-li Playlist_Musics yoxdur");
            else
                Console.WriteLine($"{id} ID-li Playlist_Musics cədvəldən silindi");
            
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void Update(Playlist_Musics model, string name)
        {
            
        }
    }
}
