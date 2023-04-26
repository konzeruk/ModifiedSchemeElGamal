using ModifiedSchemeElGamal.Interface;
namespace ModifiedSchemeElGamal
{
    /// <summary>
    /// Electronic digital signature and Digital signature verification
    /// </summary>
    public sealed partial class SEG : ISEG
    {
        public string DSV()
        {
            throw new NotImplementedException();
        }

        public string EDS()
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Encryption and Decryption text
    /// </summary>
    public sealed partial class SEG : ISEG
    {
        public string Decryption(string EncryptedText)
        {
            throw new NotImplementedException();
        }
        public string Encryption(string Text)
        {
            throw new NotImplementedException();
        }
    }
}
