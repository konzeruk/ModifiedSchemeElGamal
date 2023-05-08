using ModifiedSchemeElGamal.Model.Encryption;

namespace ModifiedSchemeElGamal.Interface
{
    /// <summary>
    /// Interface scheme ElGamal 
    /// </summary>
    internal partial interface ISEG
    {
        /// <summary>
        /// Get keys for encryption
        /// </summary>
        /// <returns>class Keys (Encryption)</returns>
        public Keys GetKeysEncryption();
        /// <summary>
        /// Encryption text
        /// </summary>
        /// <param name="Text">Text to be encrypted</param>
        /// <param name="_OpenKey">Public key</param>
        /// <returns>class Ciphertext or null, if text equals empty</returns>
        public Ciphertext? Encryption(string Text, OpenKey _OpenKey);
        /// <summary>
        /// Decryption text
        /// </summary>
        /// <param name="_Ciphertext">Ciphertext</param>
        /// <param name="_Keys">Keys (public key and private key)</param>
        /// <returns>Decryption text</returns>
        public string Decryption(Ciphertext _Ciphertext, Keys _Keys);
    }
   
}
