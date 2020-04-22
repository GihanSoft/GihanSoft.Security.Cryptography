using Xunit;

namespace GihanSoft.Security.Cryptography.Aes.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var p = "سلام";
            var c = new AesCrypto(new AesCryptoOptions { Password = "aslkd123!@#" });
            var p1 = p.Decode().Encrypt(c).Decrypt(c).Encode();
            var p2 = p.Decode().Encrypt(c).Decrypt(c).Encode();
            var p3 = p.Decode().Encrypt(c).Decrypt(c).Encode();
            var p4 = p.Decode().Encrypt(c).Decrypt(c).Encode();
            Assert.Equal(p, p1);
            Assert.Equal(p, p2);
            Assert.Equal(p, p3);
            Assert.Equal(p, p4);
        }
    }
}
