using ModifiedSchemeElGamal.Model;

namespace ModifiedSchemeElGamal.Interface
{
    internal interface ISEG
    {
        public Ciphertext Encryption(string Text, OpenKey _OpenKey);
        public string Decryption(string EncryptedText);
        //electronic digital signature
        public string EDS();
        //digital signature verification
        public string DSV();
    }
   
}
