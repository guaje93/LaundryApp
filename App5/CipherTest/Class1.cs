using EncryptStringSample;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherTest
{

    [TestFixture]
    public class CipherTest
    {
        [Test]
        public void EncrytpDecryptTest()
        {
            var test = StringCipher.Encrypt("Dupa", "Dupa");
            var test2 = StringCipher.Decrypt(test, "Dupa");
        }
    }
}
