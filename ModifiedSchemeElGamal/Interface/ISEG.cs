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
