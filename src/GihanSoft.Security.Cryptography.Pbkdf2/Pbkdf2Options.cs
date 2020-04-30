using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace GihanSoft.Security.Cryptography
{
    public class Pbkdf2Options
    {
        private byte[] salt;
        public byte[] GetSalt() => salt;
        public void SetSalt(byte[] value) => salt = value;

        public string Password { get; set; }
        public KeyDerivationPrf KeyDerivationPrf { get; set; }
        public int IterationCount { get; set; }
        public int NumBytesRequested { get; set; }
    }
}
