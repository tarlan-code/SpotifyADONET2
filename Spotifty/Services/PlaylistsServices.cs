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
    internal class PlaylistsServices : IService<Playlists>
    {
        public void Add(Playlists model)
        {
            SQL.ExecCommand($"INSERT INTO Playlists VALUES ({model.Name},{model.UserId})");
        }

        public Playlists GetById(int id)
        {
            DataTable dt = SQL.ExecQuery($"SELECT * FROM Playlists WHERE Id = {id}");
            Playlists playlists = null;
            foreach (DataRow dr in dt.Rows)
            {
                playlists = new Playlists()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = (dr["Name"]).ToString(),
                    UserId = Convert.ToInt32(dr["UserId"])
                };
            }

            return playlists;
        }

        public List<Playlists> GetData()
        {
            List<Playlists> list = new List<Playlists>();
            DataTable dt = SQL.ExecQuery("SELECT * FROM Playlists");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Playlists()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    UserId= Convert.ToInt32(dr["UserId"])
                });
            }
            return list;
        }

        public void Remove(int id)
        {
            int result = SQL.ExecCommand($"DELETE Playlists WHERE Id={id}");
            Console.ForegroundColor = ConsoleColor.Red;
            if (result == 0)
                Console.WriteLine($"{id} ID-li Playlists yoxdur");
            else
                Console.WriteLine($"{id} ID-li Playlists cədvəldən silindi");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Update(Playlists model, string name)
        {
            SQL.ExecCommand($"UPDATE Playlists SET Name = '{name}' WHERE Id = {model.Id}");
        }
    }
}
