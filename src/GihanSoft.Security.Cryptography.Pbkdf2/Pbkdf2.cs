using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Diagnostics.CodeAnalysis;

namespace GihanSoft.Security.Cryptography
{
    [SuppressMessage("Design", "CA1063:Implement IDisposable Correctly", Justification = "<Pending>")]
    public class Pbkdf2 : IHash
    {
        private readonly Pbkdf2Options options;

        public Pbkdf2(Pbkdf2Options options)
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
                options.GetSalt(),
                options.KeyDerivationPrf,
                options.IterationCount,
                options.NumBytesRequested);
        }

        void System.IDisposable.Dispose() { }
    }
}
