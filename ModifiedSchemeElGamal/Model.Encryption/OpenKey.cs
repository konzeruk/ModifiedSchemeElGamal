namespace ModifiedSchemeElGamal.Model.Encryption
{
    public sealed class OpenKey
    {
        /// <summary>
        /// Linear group
        /// </summary>
        public readonly G GL;
        /// <summary>
        /// Random linear group from G
        /// </summary>
        public readonly int[,] X;
        /// <summary>
        /// X^(private key) mod P
        /// </summary>
        public readonly int[,] Xa;
        public OpenKey(G GL, int[,] X, int[,] Xa)
        {
            this.GL = GL;
            this.X = X;
            this.Xa = Xa;
        }
    }
}
