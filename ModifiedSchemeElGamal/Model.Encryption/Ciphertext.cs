namespace ModifiedSchemeElGamal.Model.Encryption
{
    public sealed class Ciphertext
    {
        /// <summary>
        /// X^(session key) mod P
        /// </summary>
        public readonly int[,] Xr;
        /// <summary>
        /// (Xa^(session key) mod P * (digest message)) mod P
        /// </summary>
        public readonly int[,] C;
        public Ciphertext(int[,] Xr, int[,] C)
        {
            this.Xr = Xr;
            this.C = C;
        }
    }
}
