using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifty.Models
{
    internal class Users
    {
        public int Id { get; init; }
     

        string _name;
        string _surname;
        string _username;
        string _password;
        string _gender;
        public string RoleType { get; set;}
        public int RoleId { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                value = value.Trim();
                if (!String.IsNullOrEmpty(value) && value.Length <= 20) _name = value;
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                value = value.Trim();
                if (!String.IsNullOrEmpty(value) && value.Length <= 25) _surname = value;
            }
        }

        public string Username {
            get => _username;
            set
            {
                value = value.Trim();
                if (!String.IsNullOrEmpty(value) && value.Length <= 30) _username = value;
            } 
        }

        public string Password {
            get => _password;
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Length <= 30) _password = value;
            } 
        }

        public string Gender {
            get => _gender;
            set
            {
                if (!String.IsNullOrEmpty(value) && value.Length <= 6) _gender = value;
            }
        }
    }
}
