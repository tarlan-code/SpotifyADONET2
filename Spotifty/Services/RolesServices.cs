using Spotifty.Models;
using Spotifty.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotifty.Helper;
using System.Data;

namespace Spotifty.Services
{
    internal class RolesServices : IService<Roles>
    {
        public void Add(Roles model)
        {
            SQL.ExecCommand($"INSERT INTO Roles VALUES ('{model.Type}')");
        }

        public Roles GetById(int id)
        {
            DataTable dt = SQL.ExecQuery($"SELECT * FROM Roles WHERE Id = {id}");
            Roles roles = null;
            foreach (DataRow dr in dt.Rows)
            {
                roles = new Roles()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Type = (dr["Type"]).ToString(),
                };
            }

            return roles;
        }

        public List<Roles> GetData()
        {
            List<Roles> list = new List<Roles>();
            DataTable dt = SQL.ExecQuery("SELECT * FROM Roles");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Roles()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Type = dr["Type"].ToString(),
                });
            }
            return list;
        }

        public void Remove(int id)
        {
            int result = SQL.ExecCommand($"DELETE Roles WHERE Id={id}");
            Console.ForegroundColor = ConsoleColor.Red;
            if (result == 0)
                Console.WriteLine($"{id} ID-li Roles yoxdur");
            else
                Console.WriteLine($"{id} ID-li Roles cədvəldən silindi");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Update(Roles model, string name)
        {
            SQL.ExecCommand($"UPDATE Roles SET Type = '{name}' WHERE Id = {model.Id}");
        }
    }
}
