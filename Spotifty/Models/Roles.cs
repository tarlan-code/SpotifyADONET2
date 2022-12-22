using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifty.Models
{
    internal class Roles
    {
        public int Id { get; set; }
		private string _type;

		public string Type
		{
			get => _type;
			set 
			{
				value = value.Trim().ToLower();
				if (!String.IsNullOrEmpty(value) && value.Length < 25) _type = value;
			}
		}

	}
}
