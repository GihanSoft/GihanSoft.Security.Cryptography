namespace GihanSoft.Security.Cryptography
{
    public interface IHash
    {
        byte[] Hash(byte[] buffer);
    }
}
