using System;
using System.Collections.Generic;
using System.Text;

namespace UrnaLivre
{
    /// <summary>
    /// Defines an Interface for decoder
    /// </summary>
    public interface IDecoder
    {
        object Decode(byte[] encoded, Type type);

        T Decode<T>(byte[] encoded);

        object Decode(string hexString, Type type);

        T Decode<T>(string hexString);

        Type GetDefaultDecodingType();

        bool IsSupportedType(Type type);
    }
}
