using System.Security.Cryptography;

namespace GihanSoft.Security.Cryptography
{
    public class AesCryptoOptions
    {
        public string Password { get; set; }
        public int KeySize { get; set; } = 256;
        public int BlockSize { get; set; } = 128;

        public int SaltSize { get; set; } = 32;

        public CipherMode CipherMode { get; set; } = CipherMode.CBC;
    }
}
