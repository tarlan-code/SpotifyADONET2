using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifty.Validations
{
    static class Valids
    {
        public static bool CheckNull(this string Text)
        {
            if (String.IsNullOrEmpty(Text) || String.IsNullOrWhiteSpace(Text)) return true;
            return false;
        }
        
        public static bool CheckLen(this string Text,int maxlen,int minlen)
        {
            if (Text.Length <= maxlen && Text.Length >= minlen) return true;
            return false;
        }
    }
}
