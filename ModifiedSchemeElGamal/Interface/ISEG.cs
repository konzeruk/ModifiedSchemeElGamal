using ModifiedSchemeElGamal.Model;

namespace ModifiedSchemeElGamal.Interface
{
    internal interface ISEG
    {
        public Keys GetKeys();
        public Ciphertext Encryption(string Text, OpenKey _OpenKey);
        public string Decryption(Ciphertext _Ciphertext, Keys _Keys);
        //electronic digital signature
        public string EDS();
        //digital signature verification
        public string DSV();
    }
   
}
