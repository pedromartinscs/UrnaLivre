using System;
using System.Collections.Generic;
using System.Text;

namespace UrnaLivre
{
    /// <summary>
    /// Defines abstract decoder class
    /// </summary>
    public abstract class Decoder : IDecoder
    {
        public abstract bool IsSupportedType(Type type);

        public abstract object Decode(byte[] encoded, Type type);

        public abstract Type GetDefaultDecodingType();

        public T Decode<T>(byte[] encoded)
        {
            throw new NotImplementedException(); //TODO: Implement decode (from byte array) <gen>
        }

        public object Decode(string encoded, Type type)
        {
            throw new NotImplementedException(); //TODO: Implement decode (hex string with type)
        }

        public T Decode<T>(string encoded)
        {
            throw new NotImplementedException(); //TODO: Implement decode (hex string without type)
        }


    }
}
