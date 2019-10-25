using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace UrnaLivre.Services
{
    public class KeyGenerator : ECDsa
    {
        public override byte[] SignHash(byte[] hash)
        {
            throw new NotImplementedException();
        }

        public override bool VerifyHash(byte[] hash, byte[] signature)
        {
            throw new NotImplementedException();
        }
    }
}
