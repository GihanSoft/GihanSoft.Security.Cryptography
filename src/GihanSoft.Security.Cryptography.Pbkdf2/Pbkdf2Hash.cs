using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Diagnostics.CodeAnalysis;

namespace GihanSoft.Security.Cryptography
{
    [SuppressMessage("Design", "CA1063:Implement IDisposable Correctly", Justification = "<Pending>")]
    public class Pbkdf2Hash : IHash
    {
        private readonly Pbkdf2HashOptions options;

        public Pbkdf2Hash(Pbkdf2HashOptions options)
        {
            this.options = options;
        }

        public byte[] Hash(byte[] buffer)
        {
            return Hash(buffer.Encode());
        }

        public byte[] Hash(string buffer)
        {
            return KeyDerivation.Pbkdf2(
                buffer,
                options.Salt,
                options.KeyDerivationPrf,
                options.IterationCount,
                options.NumBitsRequested / 8);
        }

        void System.IDisposable.Dispose() { }
    }
}
