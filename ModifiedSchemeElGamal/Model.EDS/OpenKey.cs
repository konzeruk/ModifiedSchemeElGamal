namespace ModifiedSchemeElGamal.Model.EDS
{
    public sealed class OpenKey
    {
        /// <summary>
        /// Random prime number
        /// </summary>
        public readonly int P;
        /// <summary>
        /// primitive root P
        /// </summary>
        public readonly int G;
        /// <summary>
        /// G^(private key) mod P
        /// </summary>
        public readonly int Y;
        public OpenKey(int P, int G, int Y)
        {
            this.P = P;
            this.G = G;
            this.Y = Y;
        }
    }
}
