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
    internal class UsersServices : IService<Users>
    {
        List<Users> list = null;

        public void Add(Users model)
        {
            SQL.ExecCommand($"INSERT INTO Users VALUES ('N{model.Name}','N{model.Surname}','{model.Username}','{model.Password}','{model.Gender}',{model.RoleId})");
            Console.WriteLine("Yeni user əlavə olundu");
        }

        public Users GetById(int id)
        {
            DataTable dt = SQL.ExecQuery($"SELECT * FROM vw_GetUsers WHERE Id = {id}");
            Users user = null;

            foreach (DataRow dr in dt.Rows)
            {
                user = new Users()
                {
                    Id= Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    Surname = dr["Surname"].ToString(),
                    Username = dr["Username"].ToString(),
                    Password = dr["Password"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    RoleType = dr["Type"].ToString() //== DBNull.Value ? 0 : Convert.ToInt32(dr["RoleId"])
                };
            }

            return user;
        }

        public List<Users> GetData()
        {
            if (list == null) list = new List<Users>();
            
            DataTable dt = SQL.ExecQuery("SELECT * FROM vw_GetUsers");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Users()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    Surname = dr["Surname"].ToString(),
                    Username = dr["Username"].ToString(),
                    Password = dr["Password"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    RoleType = dr["Type"].ToString()
                });
            }
            return list;
        }

        public void Remove(int id)
        {
            int result = SQL.ExecCommand($"DELETE Users WHERE Id={id}");
            Console.ForegroundColor = ConsoleColor.Red;
            if (result == 0)
                Console.WriteLine($"{id} ID-li Users yoxdur");
            else
                Console.WriteLine($"{id} ID-li Users cədvəldən silindi");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Update(Users model, string name)
        {
            SQL.ExecCommand($"UPDATE Users SET Name = '{name}' WHERE Id = {model.Id}");
            Console.WriteLine($"Ad uğurla dəyişdirildi  {model.Name} --> {name}");
            
        }
    }
}
