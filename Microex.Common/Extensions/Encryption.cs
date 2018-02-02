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

        public static string ComputeMd5(this Stream stream)
        {
            if (!stream.CanSeek)
            {
                throw new NotSupportedException("流类型不支持该方法,请使用带有out参数的重载");
            }
            var position = stream.Position;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            var bytHash = md5.ComputeHash(stream);
            stream.Position = position;
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }

        public static string ComputeMd5(this Stream stream,out MemoryStream outStream)
        {
            var position = stream.Position;
            outStream = new MemoryStream();
            stream.CopyTo(outStream);
            outStream.Position = position;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            var bytHash = md5.ComputeHash(outStream);
            outStream.Position = position;
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }
        /// <summary>
        /// 将浏览器FileReader读取的dataurl转化成标准的base64字符串,同时获取其文件扩展名
        /// </summary>
        /// <param name="base64WithWebHeader"></param>
        /// <param name="fileExt"></param>
        /// <returns></returns>
        public static string DataUrlToBase64(this string base64WithWebHeader, out string fileExt)
        {
            var splitIndex = base64WithWebHeader.IndexOf(",");
            if (splitIndex <= 0)
            {
                throw new Exception("未找到Base64的Web Header");
            }
            var webHeader = base64WithWebHeader.Split(new[] { ',' }, 2)[0];
            if (webHeader.IndexOf("jpeg") > 0)
            {
                fileExt = "jpeg";
                return base64WithWebHeader.Substring(splitIndex + 1);
            }
            if (webHeader.IndexOf("png") > 0)
            {
                fileExt = "png";
                return base64WithWebHeader.Substring(splitIndex + 1);
            }
            throw new Exception("不支持的Base64文件格式");
        }
    }
}
