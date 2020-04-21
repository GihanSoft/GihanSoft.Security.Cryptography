namespace GihanSoft.Security.Cryptography
{
    public interface ICrypto
    {
        byte[] Encrypt(byte[] plain, bool useSalt = true);
        byte[] Decrypt(byte[] cipher, bool useSalt = true);
    }
}
