using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto;

namespace UrnaLivre
{
    /// <summary>
    /// Class responsible for creating public and private key pairs
    /// </summary>
    public class CryptoKey
    {
        public static readonly BigInteger HALF_CURVE_ORDER;
        public static readonly BigInteger CURVE_ORDER;
        public static readonly ECDomainParameters CURVE;
        public static readonly X9ECParameters _Secp256k1;
        public static X9ECParameters Secp256k1 => _Secp256k1;
        private static SecureRandom SecureRandom;

        public ECPrivateKeyParameters PrivateKey => Key as ECPrivateKeyParameters;
        private ECKeyParameters Key;


        /// <summary>
        /// Constructor for the static elements
        /// </summary>
        static CryptoKey()
        {
            _Secp256k1 = SecNamedCurves.GetByName("secp256k1");
            CURVE = new ECDomainParameters(_Secp256k1.Curve, _Secp256k1.G, _Secp256k1.N, _Secp256k1.H);
            HALF_CURVE_ORDER = _Secp256k1.N.ShiftRight(1);
            CURVE_ORDER = _Secp256k1.N;
            SecureRandom = new SecureRandom();
        }

        /// <summary>
        /// Creates a new key pair along with the CryptoKey instance
        /// </summary>
        public CryptoKey()
        {
            SecureRandom = new SecureRandom();
            GenerateKey();
        }

        /// <summary>
        /// Us
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isPrivate"></param>
        public CryptoKey(byte[] key, bool isPrivate)
        {
            if (isPrivate)
                Key = new ECPrivateKeyParameters(new BigInteger(1, key), CURVE);
            else
                Key = new ECPublicKeyParameters("EC", Secp256k1.Curve.DecodePoint(key), CURVE);
        }

        /// <summary>
        /// Method for creating a new key pair. Should only be used after creating a new secure random seed.
        /// </summary>
        public void GenerateKey()
        {
            var gen = new ECKeyPairGenerator("EC");
            var keyGenParam = new KeyGenerationParameters(SecureRandom, 256);
            gen.Init(keyGenParam);
            var keyPair = gen.GenerateKeyPair();
            var privateBytes = ((ECPrivateKeyParameters)keyPair.Private).D.ToByteArray();
            if (privateBytes.Length != 32)
                GenerateKey();
            Key = new ECPrivateKeyParameters(new BigInteger(1, privateBytes), CURVE);
        }

        public byte[] GetPubKey(bool isCompressed)
        {
            var q = GetPublicKeyParameters().Q;
            //Pub key (q) is composed into X and Y, the compressed form only include X, which can derive Y along with 02 or 03 prepent depending on whether Y in even or odd.
            q = q.Normalize();
            var result =
                Secp256k1.Curve.CreatePoint(q.XCoord.ToBigInteger(), q.YCoord.ToBigInteger()).GetEncoded(isCompressed);
            return result;
        }

        public ECPublicKeyParameters GetPublicKeyParameters()
        {
            if (Key is ECPublicKeyParameters)
                return (ECPublicKeyParameters)Key;
            var q = Secp256k1.G.Multiply(PrivateKey.D);
            return new ECPublicKeyParameters("EC", q, CURVE);
        }
    }
}
