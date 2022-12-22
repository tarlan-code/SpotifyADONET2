using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifty.Models
{
    internal class Artists
    {
         

        public int Id { get; init; }
        private string _name;
        private string _surname;
        private DateTime _birthDay;
        private string _gender;

        public string Name
        {
            get => _name; 
            set { 
                value = value.Trim();
                if (!String.IsNullOrEmpty(value) && value.Length <= 30) _name = value;
            }
        }



        public string Surname
        {
            get =>_surname; 
            set {
                value = value.Trim();
                if (!String.IsNullOrEmpty(value) && value.Length <= 30) _surname = value;
                else _surname = "NULL";
            }
        }


        public DateTime BirthDay
        {
            get => _birthDay;
            set {
                if (value <= DateTime.Now) _birthDay = value; 
            }
        }


        public string Gender
        {
            get => _gender;
            set {
                value = value.Trim();
                if (!String.IsNullOrEmpty(value) && value.Length <= 6) _gender = value;
            }
        }

    }
}
