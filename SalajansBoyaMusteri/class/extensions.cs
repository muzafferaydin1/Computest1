using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalajansBoyaMusteri 
{
    public static class extensions
    {
        public static Int32 Toint58(this object deger)
        {
            try
            {
                return Convert.ToInt32(deger);

            }
            catch (Exception)
            {

                return -111;
            }


        }
        public static DateTime ToDateTime(this object deger)
        {
            try
            {

                return Convert.ToDateTime(deger);

            }
            catch (Exception)
            {

                throw;

            }


        }
        public static Decimal ToDecimal(this object deger)
        {
            try
            {
                return Convert.ToDecimal(deger);

            }
            catch (Exception)
            {

                throw;
            }


        }
        public static Double ToDouble(this object deger)
        {
            try
            {
                return Convert.ToDouble(deger);

            }
            catch (Exception)
            {

                throw;
            }


        }
        public static string ToilkHarfBuyuk(this string Text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Text);
        }

    }
}
