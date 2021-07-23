using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Util
{
    public class CustomPasswordHasher
    {
        public static string GenerateHash(string SourceText)
        {
            UnicodeEncoding Ue = new UnicodeEncoding();
            byte[] ByteSourceText = Ue.GetBytes(SourceText);
            MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
            byte[] ByteHash = Md5.ComputeHash(ByteSourceText);
            string tmp = Convert.ToBase64String(ByteHash);
            int x = 0;
            var aStringBuilder = tmp.ToArray();
            for (x = 1; x <= tmp.Length; x++)
            {
                if (Strings.AscW(Mid(tmp, x, 1)) < 48 | (Strings.AscW(Mid(tmp, x, 1)) > 57 & Strings.AscW(Mid(tmp, x, 1)) < 65) | (Strings.AscW(Mid(tmp, x, 1)) > 90 & Strings.AscW(Mid(tmp, x, 1)) < 97) | Strings.AscW(Mid(tmp, x, 1)) > 122)
                {
                    //Strings.Mid(tmp, x, 1);
                    aStringBuilder[x - 1] = 'x';
                }
            }

            return string.Join("", aStringBuilder);
        }


        public static string Mid(string s, int a, int b)
        {
            string temp = s.Substring(a - 1, b);
            return temp;
        }
    }
}
