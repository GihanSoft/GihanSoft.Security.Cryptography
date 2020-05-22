using static System.Security.Cryptography.HashAlgorithmName;

namespace GihanSoft.Security.Cryptography
{
    public class StdHashOptions
    {
        public string HashAlgorithmName { get; set; } = SHA512.Name;
    }
}
