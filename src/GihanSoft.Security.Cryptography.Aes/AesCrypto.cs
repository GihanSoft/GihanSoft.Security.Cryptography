using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.IO;
using System.Security.Cryptography;

namespace GihanSoft.Security.Cryptography
{
    public class AesCrypto : ICrypto, IDisposable
    {
        protected readonly Aes aes;

        public AesCrypto(AesCryptoOptions options)
        {
            var key = new byte[options.KeySize / 8];
            var iv = new byte[options.BlockSize / 8];

            var keys = KeyDerivation.Pbkdf2(
                options.Password,
                new byte[128 / 8],
                KeyDerivationPrf.HMACSHA512,
                7531,
                (options.KeySize + options.BlockSize) / 8);

            Array.Copy(keys, 0, key, 0, options.KeySize / 8);
            Array.Copy(keys, options.KeySize / 8, iv, 0, options.BlockSize / 8);

            aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = options.CipherMode;
        }

        public byte[] Decrypt(byte[] cipher, bool useSalt = true)
        {
            using (var memoryStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
            {
                cryptoStream.Write(cipher, 0, cipher.Length);
                cryptoStream.Close();
                return memoryStream.ToArray();
            }
        }
        public byte[] Encrypt(byte[] plain, bool useSalt = true)
        {
            using (var memoryStream = new MemoryStream())
            using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(plain, 0, plain.Length);
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
