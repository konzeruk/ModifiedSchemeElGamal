using ModifiedSchemeElGamal.Model;

namespace ModifiedSchemeElGamal.Interface
{
    internal interface ISEG
    {
        public Keys GetKeys();
        public Ciphertext Encryption(string Text, OpenKey _OpenKey);
        public string Decryption(Ciphertext _Ciphertext, Keys _Keys);
        //electronic digital signature
        public Ciphertext? EDS(string Text, OpenKey _OpenKey);
        //digital signature verification
        public bool DSV(string Text, Ciphertext _Ciphertext, Keys _Keys);
    }
   
}
