using System;
using System.Collections.Generic;
using System.Text;

namespace UrnaLivre
{
    public interface IEncoder
    {
        byte[] Encode(object value);

        byte[] EncodePacked(object value);
    }
}
