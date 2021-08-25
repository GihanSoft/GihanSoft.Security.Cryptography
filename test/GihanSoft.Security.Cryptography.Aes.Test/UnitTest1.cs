using System.Text;

using Xunit;

using GihanSoft.Security.Cryptography.Utilities;

namespace GihanSoft.Security.Cryptography.Aes.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var p = "سلام";
            var c = new AesCrypto(new AesCryptoOptions { Password = "aslkd123!@#" });
            var p1 = p.Encode<UTF8Encoding>().Encrypt(c).Decrypt(c).Decode<UTF8Encoding>();
            var p2 = p.Encode<UTF8Encoding>().Encrypt(c).Decrypt(c).Decode<UTF8Encoding>();
            var p3 = p.Encode<UTF8Encoding>().Encrypt(c).Decrypt(c).Decode<UTF8Encoding>();
            var p4 = p.Encode<UTF8Encoding>().Encrypt(c).Decrypt(c).Decode<UTF8Encoding>();
            Assert.Equal(p, p1);
            Assert.Equal(p, p2);
            Assert.Equal(p, p3);
            Assert.Equal(p, p4);
        }
    }
}
