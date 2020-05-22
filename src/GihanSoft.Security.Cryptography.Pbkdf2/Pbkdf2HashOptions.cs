using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace GihanSoft.Security.Cryptography
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance", "CA1819:Properties should not return arrays",
        Justification = "<Pending>")]
    public class Pbkdf2HashOptions
    {
        public byte[] Salt { get; set; }
        public int IterationCount { get; set; } = 10007;
        public KeyDerivationPrf KeyDerivationPrf { get; set; }
            = KeyDerivationPrf.HMACSHA512;
        public int NumBitsRequested { get; set; } = 256;
    }
}
