using System;

namespace GihanSoft.Security.Cryptography.Utilities
{
    public static class StringExtensions
    {
        public static byte[] Encode<TEncoding>(this string src)
            where TEncoding : System.Text.Encoding
        {
            var encoding = Activator.CreateInstance<TEncoding>();
            return encoding.GetBytes(src);
        }

        public static string Decode<TEncoding>(this byte[] src)
            where TEncoding : System.Text.Encoding
        {
            var encoding = Activator.CreateInstance<TEncoding>();
            return encoding.GetString(src);
        }
    }
}
