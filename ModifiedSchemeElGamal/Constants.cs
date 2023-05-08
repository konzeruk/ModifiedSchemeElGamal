namespace ModifiedSchemeElGamal
{
    internal sealed class Constants
    {
        /// <summary>
        /// Minimal value P
        /// </summary>
        public const int MinP = 150;
        /// <summary>
        /// Maximum value P
        /// </summary>
        public const int MaxP = 300;
        /// <summary>
        /// Minimal value order
        /// </summary>
        public const int MinN = 2;
        /// <summary>
        /// Maximum value order
        /// </summary>
        public const int MaxN = 10;
        /// <summary>
        /// Number of hash functions
        /// </summary>
        public const int NumHashFunctions = 3;
        /// <summary>
        /// Special character to complete the cipher block
        /// </summary>
        public const char CompSymbol = '~';
    }
}
