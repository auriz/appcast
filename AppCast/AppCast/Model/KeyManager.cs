using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCast.Model
{
    class KeyManager
    {
        private int keyID;
        public int KeyID
        {
            get { return keyID; }
            set { keyID = value; }
        }

        private String symKey;

        public String SymKey
        {
            get { return symKey; }
            set { symKey = value; }
        }

        private String symKey2;

        public String SymKey2
        {
            get { return symKey2; }
            set { symKey2 = value; }
        }
    }
}
