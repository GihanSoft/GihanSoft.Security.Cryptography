using System.Diagnostics.CodeAnalysis;
using System.Text;

using GihanSoft.Security.Cryptography.Utilities;

using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace GihanSoft.Security.Cryptography
{
    public class Pbkdf2Hash : IHash
    {
        private readonly Pbkdf2HashOptions options;

        public Pbkdf2Hash(Pbkdf2HashOptions options)
        {
            this.options = options;
        }

        public byte[] Hash(byte[] buffer)
        {
            return Hash(buffer.Decode<UTF8Encoding>());
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
