namespace GihanSoft.Security.Cryptography
{
    public static class CryptoExtensions
    {
        public static byte[] Encrypt(this byte[] src, ICrypto crypto, bool useSalt = true)
        {
            return crypto.Encrypt(src, useSalt);
        }

        public static byte[] Encrypt(this string src, ICrypto crypto, bool useSalt = true)
        {
            return crypto.Encrypt(src.Decode(), useSalt);
        }

        public static byte[] Decrypt(this byte[] src, ICrypto crypto, bool useSalt = true)
        {
            return crypto.Decrypt(src, useSalt);
        }

        public static byte[] Decrypt(this string src, ICrypto crypto, bool useSalt = true)
        {
            return crypto.Decrypt(src.Decode(), useSalt);
        }
    }
}
