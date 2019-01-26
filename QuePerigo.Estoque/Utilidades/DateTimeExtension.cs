using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuePerigo.Estoque.Utilidades
{
    public static class DateTimeExtension
    {
        public static string ToEnglishDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }
    }
}
