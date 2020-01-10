using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace OnlineShop.Common
{
    public static class Mystring
    {
        public static string str_slug(this string str)
        {
            String[][] symbols =
            {
                new String[] { "[áàãảạâầấẫẩậăắằặẵẳ]", "a" },
                new String[] {"[đ]","d"},
                new String[] {"[éèẽẹẻêếềểệễ]","e"},
                new String[] {"[óòõỏọơớờởợỡôốồổỗộ]","o"},
                new String[] {"[úùũủụưứừữựử]","ư"},
                new String[] {"[ýỳỷỹỵ]","y"},
                new String[] {"[\\s'\";,]","-"},
            };
            str = str.ToLower();
            foreach (var ss in symbols)
            {
                str = Regex.Replace(str, ss[0], ss[1]);
            }
            return str;
        }
    }
}