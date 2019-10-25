using System;
using System.Collections.Generic;
using System.Text;

namespace UrnaLivre
{
    public class Vote
    {
        public string BlockHash { get; set; }
        public string BlockNumber { get; set; }
        public string Hash { get; set; }
        public string TimeStamp { get; set; }
        public string Candidate { get; set; }
        public string SecKey { get; set; }
        public string PublicKey { get; set; }
    }
}
