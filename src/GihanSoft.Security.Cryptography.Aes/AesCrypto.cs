using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

using GihanSoft.Security.Cryptography.Utilities;

namespace GihanSoft.Security.Cryptography
{
    public class AesCrypto : ICrypto, IDisposable
    {
        protected readonly Aes aes;
        protected readonly int SaltSize;

        public AesCrypto(AesCryptoOptions options)
        {
            SaltSize = options.SaltSize;
            var key = new byte[options.KeySize / 8];
            var iv = new byte[options.BlockSize / 8];

            var hash = SHA512.Create();

            var keys = hash.ComputeHash(options.Password.Encode<UTF8Encoding>());
            for (int i = 0; i < options.Password.Length; i++)
                keys = hash.ComputeHash(keys);

            Array.Copy(keys, 0, key, 0, options.KeySize / 8);
            Array.Copy(keys, options.KeySize / 8, iv, 0, options.BlockSize / 8);

            aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = options.CipherMode;
        }

        public byte[] Decrypt(byte[] cipher, bool useSalt = true)
        {
            if (cipher is null)
                return cipher;
            using (var memoryStream = new MemoryStream(cipher))
            using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
            using (var outStream = new MemoryStream())
            {
                cryptoStream.CopyTo(outStream);

                var plain = new byte[outStream.Length - (useSalt ? SaltSize / 8 : 0)];

                outStream.Position = 0;
                outStream.Read(plain, 0, plain.Length);
                return plain;
            }
        }
        public byte[] Encrypt(byte[] plain, bool useSalt = true)
        {
            if (plain is null)
                return plain;
            using (var memoryStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(plain, 0, plain.Length);
                if (useSalt)
                {
                    var salt = new byte[SaltSize / 8];
                    var rng = RandomNumberGenerator.Create();
                    rng.GetBytes(salt);
                    cryptoStream.Write(salt, 0, salt.Length);
                }
                cryptoStream.Close();
                return memoryStream.ToArray();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    aes.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
