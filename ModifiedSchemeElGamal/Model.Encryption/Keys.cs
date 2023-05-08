namespace ModifiedSchemeElGamal.Model.Encryption
{
    /// <summary>
    /// Keys for encryption
    /// </summary>
    public sealed class Keys
    {
        /// <summary>
        /// Public key
        /// </summary>
        public readonly OpenKey OpenKey;
        /// <summary>
        /// Private key
        /// </summary>
        public readonly int SecretKey;
        public Keys(OpenKey OpenKey, int SecretKey)
        {
            this.OpenKey = OpenKey;
            this.SecretKey = SecretKey;
        }
    }
}
