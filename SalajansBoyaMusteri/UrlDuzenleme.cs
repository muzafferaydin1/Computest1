using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalajansBoyaMusteri
{
   public class UrlDuzenleme
    {
        public static string UrlCevir(string kelime)
        {
            if (kelime == "" || kelime == null) { return ""; }

            kelime = kelime.Replace("(", "");
            kelime = kelime.Replace(")", "");
            kelime = kelime.Replace(" ", "");
            kelime = kelime.Replace("-", "");
            return kelime;
        }
    }
}
