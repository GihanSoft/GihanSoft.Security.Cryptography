namespace GihanSoft.Security.Cryptography
{
    public static class HashExtensions
    {
        public static byte[] Hash(this byte[] src, IHash hash)
        {
            return hash.Hash(src);
        }

        public static byte[] Hash(this string src, IHash hash)
        {
            return hash.Hash(src);
        }
    }
}
