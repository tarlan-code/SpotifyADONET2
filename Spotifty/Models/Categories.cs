using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifty.Models
{
    internal class Categories
    {
        public int Id { get; set; }
		private string _name;

		public string Name
		{
			get => _name;
			set 
			{
				value = value.Trim();
				if (!String.IsNullOrEmpty(value) || value.Length<=20) _name = value;
			}
		}

	}
}
