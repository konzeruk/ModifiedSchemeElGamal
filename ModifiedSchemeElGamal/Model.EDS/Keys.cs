namespace ModifiedSchemeElGamal.Model.EDS
{
    /// <summary>
    /// Keys for digital signature
    /// </summary>
    public class Keys
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