using System;

namespace GihanSoft.Security.Cryptography
{
    public interface IHash : IDisposable
    {
        byte[] Hash(byte[] buffer);
        byte[] Hash(string buffer);
    }
}
