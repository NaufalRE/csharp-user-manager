using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace UserManager.Class
{
    class SecureKey
    {
        public static string RedMd5(string input)
        {
            StringBuilder Hash = new StringBuilder();
            MD5CryptoServiceProvider Md5Provider = new MD5CryptoServiceProvider();
            byte[] MyByte = Md5Provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int xKey = 0; xKey < MyByte.Length; xKey++)
            {
                Hash.Append(MyByte[xKey].ToString("x2"));
            }
            return Hash.ToString();
        }

        public static string RedBase64Encode(string input)
        {
            var PlainTextBytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(PlainTextBytes);
        }

        public static string RedBase64Decode(string input)
        {
            var Base64 = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(Base64);
        }
    }
}
