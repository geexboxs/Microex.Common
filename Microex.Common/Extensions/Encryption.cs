using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Microex.Common.Extensions
{
    public static class Encryption
    {
        public static string ComputeMd5(this string value)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            var bytValue = System.Text.Encoding.UTF8.GetBytes(value);
            var bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }

        public static string ComputeMd5(this Stream stream)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            var bytHash = md5.ComputeHash(stream);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }

        public static string ComputeMd5(this byte[] bytes)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            var bytHash = md5.ComputeHash(bytes);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }
    }
}
