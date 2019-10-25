using System;
using System.Collections.Generic;
using System.Text;

namespace UrnaLivre
{
    /// <summary>
    /// Implements the block class
    /// </summary>
    public class Block
    {
        public string BlockNumber { get; set; }
        public string Hash { get; set; }
        public string ParentHash { get; set; }
        public string Nonce { get; set; }
        public string ExtraData { get; set; }
        public string Size { get; set; }
        public string Miner { get; set; }
        public string Votes { get; set; }
        public string Timestamp { get; set; }

    }
}
