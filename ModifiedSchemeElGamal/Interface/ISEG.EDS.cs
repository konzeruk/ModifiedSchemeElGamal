using ModifiedSchemeElGamal.Model.EDS;

namespace ModifiedSchemeElGamal.Interface
{
    /// <summary>
    /// Interface scheme ElGamal 
    /// </summary>
    internal partial interface ISEG
    {
        /// <summary>
        /// Get keys for digital signature
        /// </summary>
        /// <returns>class Keys (EDS)</returns>
        public Keys GetKeysEDS();
        /// <summary>
        /// Electronic digital signature
        /// </summary>
        /// <param name="Text">Text that is signed</param>
        /// <param name="_Keys">Keys (public key and private key)</param>
        /// <returns>class Signature or null, if text equals empty</returns>
        public Signature? EDS(string Text, Keys _Keys);
        /// <summary>
        /// Digital signature verification
        /// </summary>
        /// <param name="Text">Text that is signed</param>
        /// <param name="_Signature">Digital signature</param>
        /// <param name="_OpenKey">Public key</param>
        /// <returns>If signature verified true, else false or null, if text equals empty</returns>
        public bool? DSV(string Text, Signature _Signature, OpenKey _OpenKey);
    }
}
