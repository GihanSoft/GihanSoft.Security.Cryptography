using System;

namespace GihanSoft.Security.Cryptography
{
    public interface ICrypto : IDisposable
    {
        byte[] Encrypt(byte[] plain, bool useSalt = true);
        byte[] Decrypt(byte[] cipher, bool useSalt = true);
    }
}
