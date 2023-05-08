namespace ModifiedSchemeElGamal.Model.EDS
{
    public sealed class Signature
    {
        /// <summary>
        /// G^(session key) mod P
        /// </summary>
        public readonly int R;
        /// <summary>
        /// ((digest message) - (private key) * R)*(invert session key) (mod P-1)
        /// </summary>
        public readonly int S;
        /// <summary>
        /// Used index hash function
        /// </summary>
        public readonly int IndexHashFinction;
        public Signature(int R, int S, int IndexHashFinction)
        {
            this.R = R;
            this.S = S;
            this.IndexHashFinction = IndexHashFinction;
        }
    }
}