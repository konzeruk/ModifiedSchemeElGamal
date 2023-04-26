using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ModifiedSchemeElGamal.Interface
{
    internal interface ISEG
    {
        public string Encryption(string Text);
        public string Decryption(string EncryptedText);
        //electronic digital signature
        public string EDS();
        //digital signature verification
        public string DSV();
    }
   
}
