using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifty.Models
{
    internal class Musics
    {
        public int Id { get; init;}
        string _name;
        int _duration;
        int _categoryId;
        public TimeSpan GetDuration { get; init; }
        public int CategoryId
        {
            get => _categoryId;
            set
            {
                if (value > 0)
                {
                    _categoryId = value;
                }
            }
        }

        public int Duration
        {
            get => _duration;
            set
            {
                if (value > 0 && value <= 86400)
                {
                    _duration = value;
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                value = value.Trim();
                if (!String.IsNullOrEmpty(value) && value.Length <= 30)
                {
                    _name = value;
                }
            }
        }

     

    }
}
