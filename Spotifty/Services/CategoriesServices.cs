using Spotifty.Abstractions;
using Spotifty.Helper;
using Spotifty.Models;
using System.Data;

namespace Spotifty.Services
{
    internal class CategoriesServices : IService<Categories>
    {
        public void Add(Categories model)
        {
            SQL.ExecCommand($"INSERT INTO Categories VALUES ('{model.Name}',NULL)");
        }

        public Categories GetById(int id)
        {
            DataTable dt = SQL.ExecQuery($"SELECT * FROM Categories WHERE Id = {id}");
            Categories categories = null;
            foreach (DataRow dr in dt.Rows)
            {
                categories = new Categories()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = (dr["Name"]).ToString()
                    
                };
            }

            return categories;
        }

        public List<Categories> GetData()
        {
            List<Categories> list = new List<Categories>();
            DataTable dt = SQL.ExecQuery("SELECT * FROM Categories");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Categories()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = (dr["Name"]).ToString()
                });
            }
            return list;
        }

        public void Remove(int id)
        {
            DataTable dt = SQL.ExecQuery($"SELECT DeletedTime FROM Categories WHERE Id = {id}");
            int result = SQL.ExecCommand($"DELETE Categories WHERE Id={id}");
            Console.ForegroundColor = ConsoleColor.Red;
            if (result == 0)
                Console.WriteLine($"{id} ID-li Categories yoxdur");
            else
            {
                string DelTime = null;
                foreach (DataRow dr in dt.Rows)
                {
                    DelTime = dr[0].ToString();
                }

                if (DelTime == "") Console.WriteLine($"{id} ID-li Categories zibil qutusuna atıldı");

                else Console.WriteLine($"{id} ID-li Categories cədvəldən silindi");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Update(Categories model, string name)
        {
            SQL.ExecCommand($"UPDATE Categories SET Name = '{name}' WHERE Id = {model.Id}");
        }
    }
}
