using System.Security.Cryptography;

namespace GihanSoft.Security.Cryptography
{
    public static class StdHashExtensions
    {
        public static StdHash ToStdHash(this HashAlgorithm @this)
        {
            return new StdHash(@this);
        }
    }
}
