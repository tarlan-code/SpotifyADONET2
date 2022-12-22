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
    internal class Artist_MusicsServices : IService<Artist_Musics>
    {
        public void Add(Artist_Musics model)
        {
            SQL.ExecCommand($"INSERT INTO Artist_Musics VALUES ({model.ArtistId},{model.MusicId})");
        }

        public Artist_Musics GetById(int id)
        {
            DataTable dt = SQL.ExecQuery($"SELECT * FROM Artist_Musics WHERE Id = {id}");
            Artist_Musics artist_Musics = null;
            foreach (DataRow dr in dt.Rows)
            {
                artist_Musics = new Artist_Musics()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    ArtistId = Convert.ToInt32(dr["ArtistId"]),
                    MusicId = Convert.ToInt32(dr["MuiscId"])
                };
            }

            return artist_Musics;
        }

        public List<Artist_Musics> GetData()
        {
            List<Artist_Musics> list = new List<Artist_Musics>();
            DataTable dt = SQL.ExecQuery("SELECT * FROM Artist_Musics");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Artist_Musics()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    ArtistId = Convert.ToInt32(dr["ArtistId"]),
                    MusicId = Convert.ToInt32(dr["MuiscId"])

                });
            }
            return list;
        }

        public void Remove(int id)
        {
            
            int result = SQL.ExecCommand($"DELETE Artist_Musics WHERE Id={id}");
            Console.ForegroundColor = ConsoleColor.Red;
            if (result == 0)
                Console.WriteLine($"{id} ID-li Artist_Musics yoxdur");
            else
            {
                Console.WriteLine($"{id} ID-li Artist_Musics cədvəldən silindi");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Update(Artist_Musics model, string name)
        {
            throw new NotImplementedException();
        }
    }
}
