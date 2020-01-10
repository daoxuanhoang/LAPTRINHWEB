using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace OnlineShop.Common
{
    public class Encryptor
    {
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] resuft = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < resuft.Length; i++)
            {
                strBuilder.Append(resuft[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}